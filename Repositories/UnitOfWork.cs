using NilamHutAPI.Data;
using NilamHutAPI.Repositories.interfaces;

namespace NilamHutAPI.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
            Bid = new  BidRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public IBidRepository Bid { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}