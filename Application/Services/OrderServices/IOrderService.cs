using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Models;

namespace Application.Services.OrderServices
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(OrderDto dto);
        Task DeleteAsync(Guid id);
    }
}
