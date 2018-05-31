using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.Data;
using Microsoft.EntityFrameworkCore;
using NilamHutAPI.ViewModels.Shared;

namespace NilamHutAPI.Services
{
    public class CommonService : ICommonService
    {
        private readonly ApplicationDbContext _context;
        public CommonService(ApplicationDbContext context)
        {
            _context = context;
        }

        // City related
        public async Task<bool> AddCity(CityViewModel newCity)
        {
            var entity = new City
            {
                Id = new Guid(),
                CityName = newCity.CityName
            };
            _context.City.Add(entity);
            return 1 == await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<City>> AllCity()
        {
            return await _context.City.ToListAsync();
        }

        // City Related End

        // Country Related Starts
        public async Task<bool> AddCategory(CategoryViewModel newCategory)
        {
            var entity = new Category
            {
                Id = new Guid(),
                CategoryName = newCategory.CategoryName
            };
            _context.Category.Add(entity);
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> AllCategory()
        {
            return await _context.Category.ToListAsync();
        }
        // Counrty Related End

        // Tag Related
        public async Task<bool> AddTag(TagViewModel newtag)
        {
           var entity = new Tag
            {
                Id = new Guid(),
                TagName = newtag.TagName,
                TagDescription = newtag.TagDescription
            };
            _context.Tags.Add(entity);

            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tag>> AllTag()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<bool> DeleteTag(Guid tagId)
        {
            _context.Tags.Remove(await _context.Tags.FindAsync(tagId));

            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<bool> EditTag(Guid tagId, TagViewModel newtag)
        {
            var contex = await _context.Tags.FindAsync(tagId);

            contex.TagName = newtag.TagName;
            contex.TagDescription = newtag.TagDescription;

            try{
                await _context.SaveChangesAsync();
                return true;

            }catch{
                return false;
            }

        }

        public async Task<Tag> getSingleTag(Guid tagId)
        {
            return await _context.Tags.FindAsync(tagId);
        }

        public async Task<IEnumerable<ProductHome>> AllSearchProduct(SearchViewModel model)
        {
            return await _context.Products.Select( a => new ProductHome {
               basePrice = a.BasePrice,
               productId = a.Id,
               startDate = a.StartDateTime,
               endDate = a.EndDateTime,
               Bid = a.Bids.AsQueryable().OrderByDescending(x => x.BidPrice ).Include(x => x.ApplicationUser).FirstOrDefault(),
               Image = a.Image.AsQueryable().FirstOrDefault()
           }).AsNoTracking().ToListAsync();
        }
        // Tag related End

    }
}