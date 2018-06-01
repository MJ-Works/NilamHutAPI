using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels.Shared;

namespace NilamHutAPI.Services
{
    public interface ICommonService
    {
        Task<bool> AddCity(CityViewModel newCity);
        Task<IEnumerable<City>> AllCity();


        Task<bool> AddCategory(CategoryViewModel newCategory);
        Task<IEnumerable<Category>> AllCategory();

        Task<bool> AddTag(TagViewModel newtag);
        Task<bool> EditTag(Guid tagId, TagViewModel newtag);
        Task<bool> DeleteTag(Guid tagId);
        Task<Tag> getSingleTag(Guid tagId);
        Task<IEnumerable<Tag>> AllTag();

        Task<IEnumerable<HomeProducts>> AllSearchProduct(SearchViewModel model);


    }
}