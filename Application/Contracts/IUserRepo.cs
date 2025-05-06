using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Application.Contracts
{
    public interface IUserRepo : IGenericRepo<User>
    {
        Task<User?> LoginAsync(string username, string password);
        Task<bool> IsUsernameTakenAsync(string username);
        Task<User> GetAsync(Expression<Func<User, bool>> predicate);
    }
}
