using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NilamHutAPI.Services.interfaces
{
    public interface IServiceUnit : IDisposable
    {
        IBidService Bid { get; }
        IPostService Post { get; }
        IProductService Product { get; }
    }
}
