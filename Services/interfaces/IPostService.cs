using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.ViewModels.PostRelated;

namespace NilamHutAPI.Services.interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> Get();
        Task<Post> Get(Guid id);
        Task<string> Post(PostViewModel postFromView);
        Task<string> Put(Guid id, PostViewModel postFromView);
        Task<bool> Delete(Guid id);
    }
}
