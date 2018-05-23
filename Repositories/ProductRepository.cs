using NilamHutAPI.Data;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;

namespace NilamHutAPI.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}