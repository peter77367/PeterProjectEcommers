using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Models;

namespace Application.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> GetAllAsync() => await _unitOfWork.Products.GetAllAsync();

        public async Task<Product?> GetByIdAsync(Guid id) => await _unitOfWork.Products.GetByIdAsync(id);

        public async Task AddAsync(ProductDto dto)
        {
            var product = new Product
            {
               // ProductID = Guid.NewGuid(),
                Name = dto.Name,
                Price = dto.Price,
                //  Quantity = dto.Quantity,
              //  CategoryID = dto.CategoryID
            };
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateAsync(Guid id, ProductDto dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return;

            product.Name = dto.Name;
            product.Price = dto.Price;
         //  product. = dto.Quantity;
         //   product.CategoryID = dto.CategoryID;

            _unitOfWork.Products.Update(product);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);
            if (product == null) return;

            _unitOfWork.Products.Delete(product);
            await _unitOfWork.SaveAsync();
        }
    }
}
