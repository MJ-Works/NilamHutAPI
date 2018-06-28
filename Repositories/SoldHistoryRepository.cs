using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NilamHutAPI.Data;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.ViewModels.FrontEnd;

namespace NilamHutAPI.Repositories
{
    public class SoldHistoryRepository : Repository<SoldHistory>, ISoldHistoryRepository
    {
        private readonly  ApplicationDbContext _applicationDbContext;
        public SoldHistoryRepository(ApplicationDbContext context) : base(context)
        {
            _applicationDbContext = context;
        }
    }
}