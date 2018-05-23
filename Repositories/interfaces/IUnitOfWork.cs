using System;

namespace NilamHutAPI.Repositories.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IPostRepository Posts { get; }
        IBidRepository Bid { get; }
    }
}