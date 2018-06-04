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

        public async Task<bool> DeleteCity(Guid cityId)
        {
            var findIfLinked = await _context.City.Include(i=>i.Products).Include(i=>i.User).Where(i=>i.Id == cityId).SingleOrDefaultAsync();
            if(findIfLinked.Products.Count > 0 || findIfLinked.User.Count > 0)
                return false;
            _context.City.Remove(await _context.City.FindAsync(cityId));

            return 1 == await _context.SaveChangesAsync();
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

         public async Task<bool> DeleteCategory(Guid categoryId)
        {
            var findIfLinked = await _context.Products.Where(i=> i.CategoryId ==  categoryId).ToArrayAsync();
            if(findIfLinked.Length > 0) return false;
            _context.Category.Remove(await _context.Category.FindAsync(categoryId));

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
            var findIfLinked = await _context.ProductTags.Where(i=> i.TagId ==  tagId).ToArrayAsync();
            if(findIfLinked.Length > 0) return false;
            
            _context.Tags.Remove(await _context.Tags.FindAsync(tagId));

            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<bool> EditTag(Guid tagId, TagViewModel newtag)
        {
            var contex = await _context.Tags.FindAsync(tagId);

            contex.TagName = newtag.TagName;
            contex.TagDescription = newtag.TagDescription;

            try
            {
                await _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }

        }

        public async Task<Tag> getSingleTag(Guid tagId)
        {
            return await _context.Tags.FindAsync(tagId);
        }
        // Tag related End

        public async Task<IEnumerable<HomeProducts>> AllSearchProduct(SearchViewModel model)
        {
            var collection = await _context.Products.Select(a => new ProductHome
            {
                ProductName = a.ProductName,
                CityId = a.CityId,
                CategoryId = a.CategoryId,
                basePrice = a.BasePrice,
                productId = a.Id,
                startDate = a.StartDateTime,
                endDate = a.EndDateTime,
                Bid = a.Bids.AsQueryable().OrderByDescending(x => x.BidPrice).FirstOrDefault(),
                Image = a.Image.AsQueryable().FirstOrDefault()
            }).AsNoTracking().ToListAsync();


            List<HomeProducts> result = new List<HomeProducts>();

            // Console.WriteLine("Name"+model.searchName);
            // Console.WriteLine("Cat"+model.Category);
            // Console.WriteLine("City"+model.City);
            //Filtering And Lazy Explicit Loding                 
            foreach (var item in collection)
            {
                if (model.Category != null && item.CategoryId != model.Category) continue;
                if (model.City != null && item.CityId != model.City) continue;
                if (model.searchName != null && !item.ProductName.Contains(model.searchName)) continue;

                HomeProducts temp = new HomeProducts();
                temp.productId = item.productId;
                temp.basePrice = item.basePrice;

                if (item.Bid != null)
                {
                    temp.bidderId = item.Bid.ApplicationUserId;
                    temp.bidPrice = item.Bid.BidPrice;
                    item.Bid = await _context.Bid.Include(x => x.ApplicationUser).SingleAsync(y => y.Id == item.Bid.Id);
                    temp.bidderName = item.Bid.ApplicationUser.UserName;
                }
                temp.image = item.Image.ImgPath;
                temp.startDate = item.startDate;
                temp.endDate = item.endDate;

                result.Add(temp);
            }

            return (IEnumerable<HomeProducts>)result;
        }

    }
}