using NilamHutAPI.Data;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;

namespace NilamHutAPI.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}