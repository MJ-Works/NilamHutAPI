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
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _repository;

        public PostService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Post>> Get()
        {
            return await _repository.Posts.GetAll();
        }

        public async Task<Post> Get(Guid id)
        {
            return await _repository.Posts.Get(id);
        }

        public async Task<string> Post(PostViewModel post)
        {
            Post entity = new Post
            {
                Id = new Guid(),
                ApplicationUserId = post.ApplicationUserId,
                StartDateTime = post.StartDateTime,
                EndDateTime = post.EndDateTime,
                ContactInfo = post.ContactInfo,
                CountryId = post.CountryId,
                CityId = post.CityId
            };
            int success = await _repository.Posts.Add(entity);
            if (1 == success) return entity.Id.ToString();
            else return "Unsucessfull";
        }

        public async Task<string> Put(Guid id, PostViewModel postFromView)
        {
            Post entity = new Post
            {
                Id = id,
                ApplicationUserId = postFromView.ApplicationUserId,
                StartDateTime = postFromView.StartDateTime,
                EndDateTime = postFromView.EndDateTime,
                ContactInfo = postFromView.ContactInfo,
                CountryId = postFromView.CountryId,
                CityId = postFromView.CityId
            };
            int success = await _repository.Posts.Update(id, entity);
            if (1 == success) return entity.Id.ToString();
            else return "Unsucessfull";
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.Posts.Get(id);
            int result = await _repository.Posts.Remove(entity);
            if (1 == result) return true;
            return false;
        }
    }
}