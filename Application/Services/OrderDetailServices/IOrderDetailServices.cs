using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs;
using Models;

namespace Application.Services.OrderDetailServices
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetAllByOrderIdAsync(Guid orderId);
        Task AddAsync(OrderDetailDto dto);
    }
}
