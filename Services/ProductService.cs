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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _repository;

        public ProductService(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            return await _repository.Products.GetAll();
        }

        public async Task<Product> Get(Guid id)
        {
            return await _repository.Products.Get(id);
        }

        public async Task<string> Post(ProductViewModel product)
        {
            Product entity = new Product
            {
                Id = Guid.NewGuid(),
                ApplicationUserId = product.ApplicationUserId,
                StartDateTime = product.StartDateTime,
                EndDateTime = product.EndDateTime,
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                Quantity = product.Quantity,
                BasePrice = product.BasePrice,
                ContactInfo = product.ContactInfo,
                CategoryId = product.CategoryId,
                CityId = product.CityId
            };

            //fsave product
            int successProduct = await _repository.Products.Add(entity);
            if (1 != successProduct) return "Unsucessfull";

            //save image to database and add image path to database
            string successImageUploadAndDataSave = await _repository.Products.AddImage(entity.Id, product.Image);
            if (successImageUploadAndDataSave != "Successfull") return successImageUploadAndDataSave;

            //save tags to database
            int tagDataSave = await _repository.Products.AddTag(entity.Id, product.Tags);
            if(tagDataSave != product.Tags.Count) return "Unsucessfull";

            return entity.Id.ToString();


        }

        public Task<string> Put(Guid id, ProductViewModel postFromView)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Delete(Guid id)
        {
            var entity = await _repository.Products.Get(id);
            int result = await _repository.Products.Remove(entity);
            if (1 == result) return true;
            return false;
        }
    }
}
