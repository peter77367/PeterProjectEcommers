using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Application.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(Guid id);
        Task AddAsync(CategoryDto dto);
        Task UpdateAsync(Guid id, CategoryDto dto);
        Task DeleteAsync(Guid id);
    }
}
