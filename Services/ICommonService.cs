using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels;

namespace NilamHutAPI.Services
{
    public interface ICommonService
    {
        Task<bool> AddCity(CityViewModel newCity);
        Task<IEnumerable<City>> AllCity();


        Task<bool> AddCountry(CountryViewModel newCountry);
        Task<IEnumerable<Country>> AllCountrty();


        Task<bool> AddTag(TagViewModel newtag);
        Task<bool> EditTag(Guid tagId, TagViewModel newtag);
        Task<bool> DeleteTag(Guid tagId);
        Task<Tag> getSingleTag(Guid tagId);
        Task<IEnumerable<Tag>> AllTag();

    }
}