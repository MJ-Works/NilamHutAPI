using System;
using NilamHutAPI.Data;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NilamHutAPI.ViewModels.FrontEnd;

namespace NilamHutAPI.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<string> AddUserAsync(UserViewModel user)
        {
            var testIsAlreadyCreated = await _context.User.FirstOrDefaultAsync(x => x.ApplicationUserId == user.ApplicationUserId);
            if (testIsAlreadyCreated != null) //for disable posting multiple data for one application user through api
                return "Already Created";                //one application user can have only one User information

            User newUser = new User
            {
                Id = new Guid(),
                ApplicationUserId = user.ApplicationUserId,
                FullName = user.FullName,
                CityId = user.CityId,
                PostCode = user.PostCode,
                Address = user.Address,
                Phone = user.Phone,
                IsVip = user.IsVip
            };

            if (user.Image != null)
            {
                var result = await AddImage(user.Image);
                if (result == "Unsuccessfull") return "image Upload unsuccessfull";
                newUser.Image = result;
            }

            _context.User.Add(newUser);

            var saveResult = await _context.SaveChangesAsync();

            if (saveResult == 1) return "SuccessFull";
            return "Error In Database";
        }

        public async Task<bool> EditUserAsync(UserViewModel user)
        {
            var findUser = await _context.User.SingleAsync(x => x.ApplicationUserId == user.ApplicationUserId);
            if (user.FullName != null)
                findUser.FullName = user.FullName;
            if (user.CityId != null)
                findUser.CityId = user.CityId;
            if (user.PostCode != null)
                findUser.PostCode = user.PostCode;
            if (user.Address != null)
                findUser.Address = user.Address;
            if (user.Phone != null)
                findUser.Phone = user.Phone;
            if (user.IsVip)
                findUser.IsVip = user.IsVip;

            // if (user.Image != null)
            // {
            //     var result = await AddImage(user.Image);
            //     if (result == "Unsuccessfull") return false;
            //     findUser.Image = result;
            // }


            var saveResult = await _context.SaveChangesAsync();

            if (saveResult == 1) return true;
            return false;
        }

        public async Task<UserInfo> GetUserAsync(string applicationUser)
        {
            var collection = await _context.User.Include(x => x.ApplicationUser).SingleAsync(x => x.ApplicationUserId == applicationUser);
            UserInfo result = new UserInfo();
            result.userId = collection.Id;
            result.applicationUserId = collection.ApplicationUserId;
            result.cityId = collection.CityId;
            result.fullName = collection.FullName;
            result.image = collection.Image;
            result.postCode = collection.PostCode;
            result.phone = collection.Phone;
            result.email = collection.ApplicationUser.Email;
            result.address = collection.Address;
            var collection2 = await _context.City.FindAsync(result.cityId);
            if (collection2 != null) result.cityName = collection2.CityName;
            return result;
        }

        public async Task<string> AddImage(IFormFile img)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var message = "";

            var extention = Path.GetExtension(img.FileName);

            if (img.Length > 2000000)
                message = "Select jpg or jpeg or png less than 2Μ";
            else if (!allowedExtensions.Contains(extention.ToLower()))
                message = "Must be jpeg or png";

            var fileName = Path.Combine("Products", DateTime.Now.Ticks + extention);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName);
            try
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await img.CopyToAsync(stream);
                }
            }
            catch
            {
                message = "can not upload image";
            }

            //if already image exists

            if (message == "") return message = fileName;

            return message = "Unsuccessfull";
        }

        public async Task<IEnumerable<UserPosts>> GetUserPosts(string id)
        {
            var collection = await _context.Products.Where(X => X.ApplicationUserId == id).ToListAsync();
            List<UserPosts> result = new List<UserPosts>();
            foreach (var item in collection)
            {
                UserPosts temp = new UserPosts
                {
                    PostId = item.Id,
                    ProductName = item.ProductName,
                    StartDateTime = item.StartDateTime,
                    EndDateTime = item.EndDateTime
                };
                result.Add(temp);
            }
            return (IEnumerable<UserPosts>)result;
        }

        public async Task<IEnumerable<UserBids>> GetUserBids(string id)
        {
            var collection = await _context.Bid.Include(X => X.Products).Where(X => X.ApplicationUserId == id).ToListAsync();
            List<UserBids> result = new List<UserBids>();

            foreach (var item in collection)
            {
                UserBids temp = new UserBids
                {
                    BidId = item.Id,
                    ProductId = item.ProductId,
                    ProductName = item.Products.ProductName,
                    BidTime = item.BidTime,
                    BidPrice = item.BidPrice
                };
                result.Add(temp);
            }
            return (IEnumerable<UserBids>)result;
        }
    }
}