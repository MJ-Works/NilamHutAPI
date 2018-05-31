using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NilamHutAPI.Data;
using NilamHutAPI.Models;
using NilamHutAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using NilamHutAPI.Auth;
using NilamHutAPI.Services;
using System.Linq;
using NilamHutAPI.Repositories;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.Services.interfaces;
using NilamHutAPI.Hubs;
using NilamHutAPI.ViewModels;

namespace NilamHutAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                                    b => b.MigrationsAssembly("NilamHutAPI")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


             services.AddScoped<IJwtFactory, JwtFactory>();
             services.AddScoped<IUserService,UserService>();
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceUnit, ServiceUnit>();


            // Get options from app settings
            var jwtAppSettingOptions = Configuration.GetSection(nameof(JwtIssuerOptions));

            SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtAppSettingOptions["SecreatKey"]));
            // Configure JwtIssuerOptions
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                options.Audience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)];
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)],

                ValidateAudience = true,
                ValidAudience = jwtAppSettingOptions[nameof(JwtIssuerOptions.Audience)],

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = false,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(configureOptions =>
            {
                configureOptions.ClaimsIssuer = jwtAppSettingOptions[nameof(JwtIssuerOptions.Issuer)];
                configureOptions.TokenValidationParameters = tokenValidationParameters;
                configureOptions.SaveToken = true;
            });

            // api user claim policy
            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(Constants.Strings.UserRoles.Administrator), policy => policy.RequireClaim("Rol", Constants.Strings.UserRoles.Administrator));
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(nameof(Constants.Strings.UserRoles.SimpleUser), policy => policy.RequireClaim("Rol", Constants.Strings.UserRoles.SimpleUser));

            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                               .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    });
            });

            services.AddSignalR();

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1).AddJsonOptions(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
                               RoleManager<IdentityRole> roleManager,
                                UserManager<ApplicationUser> userManager,
                                IUserService userService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
                app.UseHsts();

            //create roles needed for application

            EnsureRolesAsync(roleManager).Wait();

            //Create an account and make it administrator
            AssignAdminRole(userManager,userService).Wait();

            app.UseCors("AllowSpecificOrigin");
            app.UseSignalR(routes => {
                routes.MapHub<NotifyBidHub>("/updateBidList");
            });
            
            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseHttpsRedirection();

            app.UseMvc();
        }

        //create needed roles
        public static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExistsAdmin = await roleManager.RoleExistsAsync(Constants.Strings.UserRoles.Administrator);
            var alreadyExistsSimpleUser = await roleManager.RoleExistsAsync(Constants.Strings.UserRoles.SimpleUser);

            if (alreadyExistsAdmin) return;
            else await roleManager.CreateAsync(new IdentityRole(Constants.Strings.UserRoles.Administrator));

            if (alreadyExistsSimpleUser) return;
            else await roleManager.CreateAsync(new IdentityRole(Constants.Strings.UserRoles.SimpleUser));
        }

        //add a default administrator
        public static async Task AssignAdminRole(UserManager<ApplicationUser> userManager,IUserService userService)
        {
            var testAdmin = await userManager.Users.Where(x => x.UserName == "IAmMonmoy").SingleOrDefaultAsync();
            if (testAdmin == null)
            {
                testAdmin = new ApplicationUser
                {
                    UserName = "IAmMonmoy",
                    Email = "iammonmoy@gmail.com"
                };

                await userManager.CreateAsync(testAdmin, "512345Rrm-");
                await userManager.AddToRoleAsync(testAdmin, Constants.Strings.UserRoles.Administrator);
                
                ApplicationUser getUser = await userManager.FindByNameAsync(testAdmin.UserName);

                var addUserInfo = new UserViewModel
                {
                    ApplicationUserId = getUser.Id
                };

                await userService.AddUserAsync(addUserInfo);
            }
            else
            {
                var isAdmin = await userManager.IsInRoleAsync(testAdmin, Constants.Strings.UserRoles.Administrator);
                if (!isAdmin) await userManager.AddToRoleAsync(testAdmin, Constants.Strings.UserRoles.Administrator);
            }
        }
    }
}
