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
            var testIsAlreadyCreated = await _context.User.FirstOrDefaultAsync(x=>x.ApplicationUserId == applicationUser);
            if(testIsAlreadyCreated != null) //for disable posting multiple data for one application user through api
                return false;                //one application user can have only one User information

            User newUser = new User{
                Id = new Guid(),
                ApplicationUserId = applicationUser,
                FullName = user.FullName,
                CountryId = user.CountryId,
                CityId = user.CityId,
                PostCode = user.PostCode,
                Address = user.Address,
                Phone = user.Phone
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