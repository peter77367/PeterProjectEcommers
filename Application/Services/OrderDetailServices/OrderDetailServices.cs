using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using DTOs;
using Models;

namespace Application.Services.OrderDetailServices
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderDetailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OrderDetail>> GetAllByOrderIdAsync(Guid orderId)
        {
            var all = await _unitOfWork.OrderDetails.GetAllAsync();
            // return all.Where(od => od.OrderID == orderId);
            return null;
        }

        public async Task AddAsync(OrderDetailDto dto)
        {
            var detail = new OrderDetail
            {
                //Id = Guid.NewGuid(),
                //OrderId = dto.OrderId,
                //ProductId = dto.ProductId,
                //Quantity = dto.Quantity,
                //UnitPrice = dto.UnitPrice
            };

            await _unitOfWork.OrderDetails.AddAsync(detail);
            await _unitOfWork.SaveAsync();
        }
    }
}
