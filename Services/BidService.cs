using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.Services.interfaces;
using NilamHutAPI.ViewModels.PostRelated;

namespace NilamHutAPI.Services
{
    public class BidService : IBidService
    {
        private readonly IUnitOfWork _repository;

        public BidService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Bid>> Get()
        {
            return await _repository.Bid.GetAll();
        }

        public async Task<Bid> Get(Guid id)
        {
            return await _repository.Bid.Get(id);
        }

        public async Task<string> Post(BidViewModel bidFromView)
        {
            Bid entity = new Bid
            {
                Id = new Guid(),
                ApplicationUserId = bidFromView.ApplicationUserId,
                BidPrice = bidFromView.BidPrice,
                ProductId = bidFromView.PostId
            };
            int success = await _repository.Bid.Add(entity);
            if (1 == success) return entity.Id.ToString();
            else return "Unsucessfull";
        }

        public async Task<string> Put(Guid id, BidViewModel bidFromView)
        {
            Bid entity = new Bid
            {
                Id = id,
                ApplicationUserId = bidFromView.ApplicationUserId,
                BidPrice = bidFromView.BidPrice,
                ProductId = bidFromView.PostId
            };
            int success = await _repository.Bid.Update(id, entity);
            if (1 == success) return entity.Id.ToString();
            else return "Unsucessfull";
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.Bid.Get(id);
            int result = await _repository.Bid.Remove(entity);
            if (1 == result) return true;
            return false;
        }
    }
}
