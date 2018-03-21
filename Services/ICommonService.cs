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
        Task<bool> AddCountry(CountryViewModel newCountry);
        Task<IEnumerable<City>> AllCity();
        Task<IEnumerable<Country>> AllCountrty();

    }
}