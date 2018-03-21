using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.Data;
using NilamHutAPI.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace NilamHutAPI.Services
{
    public class CommonService : ICommonService
    {
        private readonly ApplicationDbContext _context;
        public CommonService(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public async Task<bool> AddCountry(CountryViewModel newCountry)
        {
            var entity = new Country
            {
                Id = new Guid(),
                CountryName = newCountry.CountryName
            };
            _context.Country.Add(entity);
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> AllCity()
        {
            return await _context.City.ToListAsync();
        }
        
        public async Task<IEnumerable<Country>> AllCountrty()
        {
            return await _context.Country.ToListAsync();
        }
    }
}