using System;
using NilamHutAPI.Data;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace NilamHutAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUserAsync(UserViewModel user, ApplicationUser applicationUser)
        {
            User newUser = new User{
                Id = new Guid(),
                ApplicationUserId = applicationUser.Id,
                FullName = user.FullName,
                CountryId = user.CountryId,
                CityId = user.CityId,
                PostCode = user.PostCode,
                Address = user.Address,
                Phone = user.Phone,
                UserRating = 0
            };
            
            _context.User.Add(newUser);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> EditUserAsync(UserViewModel user, ApplicationUser applicationUser)
        {
            var findUser = await _context.User.SingleAsync(x=>x.ApplicationUserId == applicationUser.Id);

            findUser.FullName = user.FullName;
            findUser.CountryId = user.CountryId;
            findUser.CityId = user.CityId;
            findUser.PostCode = user.PostCode;
            findUser.Address = user.Address;
            findUser.Phone = user.Phone;

            var saveResult = await _context.SaveChangesAsync();

            return saveResult >= 1;
        }

        public async Task<User> GetUserAsync(ApplicationUser applicationUser)
        {
            return await _context.User.SingleAsync(x=>x.ApplicationUserId == applicationUser.Id);
        }
    }
}