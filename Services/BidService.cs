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
            //check already exists
            var alreadyBid = await _repository.Bid.Find( s=> s.ApplicationUserId == bidFromView.ApplicationUserId && s.ProductId == bidFromView.ProductId);
            
            Bid entity = new Bid
            {
                ApplicationUserId = bidFromView.ApplicationUserId,
                BidPrice = bidFromView.BidPrice,
                ProductId = bidFromView.ProductId
            };

            //if exists update
            if(alreadyBid != null && alreadyBid.Any())
            {
                entity.Id = alreadyBid.ElementAt(0).Id;
                int update = await _repository.Bid.Update(alreadyBid.ElementAt(0).Id,entity);
                if(1 == update) return entity.Id.ToString();
                else return "Unsucessfull";
            }

            //otherwise create
            entity.Id = Guid.NewGuid();
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
                ProductId = bidFromView.ProductId
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
