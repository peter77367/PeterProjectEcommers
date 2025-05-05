using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Context;
using Microsoft.EntityFrameworkCore;
using Models;
using Application.Contracts;

namespace Infrastructrure
{
    public class UserRepo : GenericRepo<User> , IUserRepo
    {
        private readonly PeterDbContext _context;

        public UserRepo(PeterDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task<User?> LoginAsync(string username, string password)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.PasswordHash == password);
        }



        public async Task<bool> IsUsernameTakenAsync(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }
    }
}
