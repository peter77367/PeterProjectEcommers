using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Application.Contracts;

namespace Application.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepo Users { get; }
        IGenericRepo<Product> Products { get; }
        IGenericRepo<Category> Categories { get; }
        IGenericRepo<Order> Orders { get; }
        IGenericRepo<OrderDetail> OrderDetails { get; }

        Task SaveAsync();
    } 
}
