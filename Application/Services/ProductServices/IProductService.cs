using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Application.Services.ProductServices
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(Guid id);
        Task AddAsync(ProductDto dto);
        Task UpdateAsync(Guid id, ProductDto dto);
        Task DeleteAsync(Guid id);
    }
}
