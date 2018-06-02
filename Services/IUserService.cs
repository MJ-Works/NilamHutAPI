using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;

namespace NilamHutAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string applicationUser);
        Task<string> AddUserAsync(UserViewModel user);
        Task<bool> EditUserAsync(UserViewModel user);
        Task<string> AddImage(IFormFile image);
    }
}