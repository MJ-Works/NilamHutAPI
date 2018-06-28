using System;

namespace NilamHutAPI.Repositories.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository Products { get; }
        IBidRepository Bid { get; }
        ISoldHistoryRepository SoldRepository { get; }
    }
}