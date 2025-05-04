using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Application.Services.OrderServices;
using DTOs;
using Models;

namespace Application.Services.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _unitOfWork.Orders.GetAllAsync();

        public async Task<Order?> GetByIdAsync(Guid id) =>
            await _unitOfWork.Orders.GetByIdAsync(id);

        public async Task<Guid> AddAsync(OrderDto dto)
        {
            var order = new Order
            {
                // OrderID = Guid.NewGuid(), // Uncomment if needed and adjust type
                UserID = ConvertGuidToInt(dto.UserId), // Use a helper method to convert Guid to int
                OrderDate = dto.OrderDate,
                TotalAmount = dto.TotalAmount
            };

            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveAsync();

            return dto.UserId; // Return the original Guid from the DTO
        }

        // Helper method to convert Guid to int
        private int ConvertGuidToInt(Guid guid)
        {
            // Use a hash code or other deterministic method to convert Guid to int
            return BitConverter.ToInt32(guid.ToByteArray(), 0);
        }

        public async Task DeleteAsync(Guid id)
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order == null) return;

            _unitOfWork.Orders.Delete(order);
            await _unitOfWork.SaveAsync();
        }
    }
}
