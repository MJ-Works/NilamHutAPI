using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels.PostRelated;

namespace NilamHutAPI.Services.interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> Get();
        Task<Product> Get(Guid id);
        Task<string> Post(ProductViewModel postFromView);
        Task<string> Put(Guid id, ProductViewModel postFromView);
        Task<bool> Delete(Guid id);
    }
}
