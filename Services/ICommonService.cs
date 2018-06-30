using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels.FrontEnd;
using NilamHutAPI.ViewModels.Shared;

namespace NilamHutAPI.Services
{
    public interface ICommonService
    {
        Task<bool> AddCity(CityViewModel newCity);
        Task<IEnumerable<City>> AllCity();
        Task<bool> DeleteCity(Guid cityId);

        Task<bool> AddCategory(CategoryViewModel newCategory);
        Task<IEnumerable<Category>> AllCategory();
        Task<bool> DeleteCategory(Guid categoryId);

        Task<bool> AddTag(TagViewModel newtag);
        Task<bool> EditTag(Guid tagId, TagViewModel newtag);
        Task<bool> DeleteTag(Guid tagId);
        Task<Tag> getSingleTag(Guid tagId);
        Task<IEnumerable<Tag>> AllTag();
        Task<List<SoldHistory>> getSoldHistory(string id);
        Task<List<SoldHistory>> getWinHistory(string id);

        Task<IEnumerable<Report>> AllReport();
        Task<bool> AddReport(ReportViewModel report);

        Task<IEnumerable<HomeProducts>> AllSearchProduct(SearchViewModel model);


    }
}