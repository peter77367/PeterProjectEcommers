using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Application.Contracts;
using Context;


namespace Infrastructrure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PeterDbContext _context;

        public IUserRepo Users { get; }
        public IGenericRepo<Product> Products { get; }
        public IGenericRepo<Category> Categories { get; }
        public IGenericRepo<Order> Orders { get; }
        public IGenericRepo<OrderDetail> OrderDetails { get; }

        public UnitOfWork(PeterDbContext context)
        {
            _context = context;
            Users = new UserRepo(_context);
            Products = new GenericRepo<Product>(_context);
            Categories = new GenericRepo<Category>(_context);
            Orders = new GenericRepo<Order>(_context);
            OrderDetails = new GenericRepo<OrderDetail>(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
