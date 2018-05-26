using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NilamHutAPI.Data;
using NilamHutAPI.Repositories;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.Services.interfaces;

namespace NilamHutAPI.Services
{
    public class ServiceUnit : IServiceUnit
    {
        private readonly IUnitOfWork _context;

        public ServiceUnit(IUnitOfWork context)
        {
            _context = context;
            Bid = new BidService(_context);
            Product = new ProductService(_context);
        }

        public IBidService Bid { get; }
        public IProductService Product { get; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
