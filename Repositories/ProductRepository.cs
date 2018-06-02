using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NilamHutAPI.Data;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;

namespace NilamHutAPI.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<string> AddImage(Guid id, List<IFormFile> images)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
            var message = "";
            foreach (var img in images)
            {
                //save image to server
                var extention = Path.GetExtension(img.FileName);

                if (img.Length > 2000000)
                    message = "Select jpg or jpeg or png less than 2Μ";
                else if (!allowedExtensions.Contains(extention.ToLower()))
                    message = "Must be jpeg or png";
                else if (images.Count > 5)
                    message = "You Can Select At Most 5 Images";

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

                //save image path to database
                var imageEntity = new Image
                {
                    Id = new Guid(),
                    ProductId = id,
                    ImgPath = fileName
                };

                _context.Images.Add(imageEntity);
            }

            int result = await _context.SaveChangesAsync();

            if (message == "" && result == images.Count) message = "Successfull";

            return message;
        }

        public async Task<int> AddTag(Guid id, List<Guid> tags)
        {
            foreach (var tag in tags)
            {
                var tagEntity = new ProductTag
                {
                    ProductId = id,
                    TagId = tag
                };
                _context.ProductTags.Add(tagEntity);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<Product> GetWithRelatedData(Guid id)
        {
            return await _context.Products.Include(i => i.ApplicationUser)
                                                 .ThenInclude(i => i.User)
                                          .Include(i => i.Category)
                                           .Include(i => i.City)
                                           .Include(i => i.Bids)
                                              .ThenInclude(i => i.ApplicationUser)
                                                 .ThenInclude(i => i.User)
                                            .Include(i => i.Image)
                                            .Include(i => i.Tags)
                                            .Where( i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}