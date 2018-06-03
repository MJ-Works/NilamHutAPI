using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;
using NilamHutAPI.ViewModels.FrontEnd;

namespace NilamHutAPI.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string applicationUser);
        Task<string> AddUserAsync(UserViewModel user);
        Task<bool> EditUserAsync(UserViewModel user);
        Task<string> AddImage(IFormFile image);
        Task<IEnumerable<UserPosts>> GetUserPosts(string id);
        Task<IEnumerable<UserBids>> GetUserBids(string id);


    }
}