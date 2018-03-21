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
        public async Task<bool> AddUserAsync(UserViewModel user, string applicationUser)
        {
            City city = new City{
                Id = new Guid(),
                CityName = "Dhaka"
            };

            Country country = new Country{
                Id = new Guid(),
                CountryName = "Bangladesh"
            };

            _context.City.Add(city);
            _context.Country.Add(country);
            
            User newUser = new User{
                Id = new Guid(),
                ApplicationUserId = applicationUser,
                FullName = user.FullName,
                CountryId = country.Id,
                CityId = city.Id,
                PostCode = user.PostCode,
                Address = user.Address,
                Phone = user.Phone,
                UserRating = 0
            };
            
            _context.User.Add(newUser);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> EditUserAsync(UserViewModel user, string applicationUser)
        {
            var findUser = await _context.User.SingleAsync(x=>x.ApplicationUserId == applicationUser);

            findUser.FullName = user.FullName;
            findUser.CountryId = user.CountryId;
            findUser.CityId = user.CityId;
            findUser.PostCode = user.PostCode;
            findUser.Address = user.Address;
            findUser.Phone = user.Phone;

            var saveResult = await _context.SaveChangesAsync();

            return saveResult >= 1;
        }

        public async Task<User> GetUserAsync(string applicationUser)
        {
            return await _context.User.SingleAsync(x=>x.ApplicationUserId == applicationUser);
        }
    }
}