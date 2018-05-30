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
        public async Task<bool> AddUserAsync(UserViewModel user)
        {
            var testIsAlreadyCreated = await _context.User.FirstOrDefaultAsync(x=>x.ApplicationUserId == user.ApplicationUserId);
            if(testIsAlreadyCreated != null) //for disable posting multiple data for one application user through api
                return false;                //one application user can have only one User information

            User newUser = new User{
                Id = new Guid(),
                ApplicationUserId = user.ApplicationUserId,
                FullName = user.FullName,
                CityId = user.CityId,
                PostCode = user.PostCode,
                Address = user.Address,
                Phone = user.Phone,
                Image = user.Image,
                IsVip = user.IsVip
            };
            
            _context.User.Add(newUser);
            var saveResult = await _context.SaveChangesAsync();
            return saveResult == 1;
        }

        public async Task<bool> EditUserAsync(UserViewModel user)
        {
            var findUser = await _context.User.SingleAsync(x=>x.ApplicationUserId == user.ApplicationUserId);

            findUser.FullName = user.FullName;
            findUser.CityId = user.CityId;
            findUser.PostCode = user.PostCode;
            findUser.Address = user.Address;
            findUser.Phone = user.Phone;
            findUser.Image = user.Image;
            findUser.IsVip = user.IsVip;

            var saveResult = await _context.SaveChangesAsync();

            return saveResult >= 1;
        }

        public async Task<User> GetUserAsync(string applicationUser)
        {
            return await _context.User.SingleAsync(x=>x.ApplicationUserId == applicationUser);
        }
    }
}