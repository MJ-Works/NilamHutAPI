using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;

namespace NilamHutAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string applicationUser);
        Task<bool> AddUserAsync(UserViewModel user, string applicationUser);
        Task<bool> EditUserAsync(UserViewModel user, string applicationUser);
    }
}