using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NilamHutAPI.Models;

namespace NilamHutAPI.Repositories.interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<string> AddImage(Guid id, List<IFormFile> images);
        Task<int> AddTag(Guid id, List<Guid> tags);
        Task<Product> GetWithRelatedData(Guid id);
    }
}
