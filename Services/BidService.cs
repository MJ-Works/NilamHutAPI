using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NilamHutAPI.Models;
using NilamHutAPI.Repositories.interfaces;
using NilamHutAPI.Services.interfaces;
using NilamHutAPI.ViewModels.PostRelated;
using NilamHutAPI.ViewModels.FrontEnd;

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
            var alreadyBid = await _repository.Bid.Find(s => s.ApplicationUserId == bidFromView.ApplicationUserId && s.ProductId == bidFromView.ProductId);
            var product = await _repository.Products.Get(bidFromView.ProductId);

            if (product == null) return "We Can't Find any product";

            if (bidFromView.BidPrice < product.BasePrice) return "You Must Bid Greater than or equal base price";

            var bids = await _repository.Bid.Find(d => d.ProductId == bidFromView.ProductId);
            bids.OrderByDescending(i => i.BidPrice);

            // Console.WriteLine(bids.Count());
            
            if (bids.Count() > 0 && bidFromView.BidPrice <= bids.ElementAt(0).BidPrice) return "You Must Bid higher than or current highest bid";

            Bid entity = new Bid
            {
                ApplicationUserId = bidFromView.ApplicationUserId,
                BidTime = bidFromView.BidTime,
                BidPrice = bidFromView.BidPrice,
                ProductId = bidFromView.ProductId
            };

            //if exists update
            if (alreadyBid != null && alreadyBid.Any())
            {
                if (bidFromView.BidPrice <= alreadyBid.ElementAt(0).BidPrice) return "You Must Bid Greater than your previous bid";
                entity.Id = alreadyBid.ElementAt(0).Id;
                int update = await _repository.Bid.Update(alreadyBid.ElementAt(0).Id, entity);
                if (1 == update) return entity.Id.ToString();
                else return "Duplicate bid price or server error.";
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
                BidTime = bidFromView.BidTime,
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
        public async Task<BidFrontEnd> BidForProductView(Guid id)
        {
            var entity = await _repository.Bid.BidForProductView(id);
            BidFrontEnd bid = new BidFrontEnd
            {
                BidPrice = entity.BidPrice,
                BidTime = entity.BidTime,
                UserId = new Guid(entity.ApplicationUserId),
                UserName = entity.ApplicationUser.UserName,
                userAddress = entity.ApplicationUser.User.Address,
                ProductId = entity.ProductId.Value
            };
            return bid;
        }
    }
}
