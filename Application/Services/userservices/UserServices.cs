using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts;
using Models;

namespace Application.Services.userservices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> RegisterAsync(UserRegisterDto dto)
        {
            bool exists = await _unitOfWork.Users.IsUsernameTakenAsync(dto.Username);
            if (exists)
                return false;

            var user = new User
            {
              //  UserID = Guid.NewGuid(),
                Username = dto.Username,
                PasswordHash = dto.Password,
                Email = dto.Email,
                Role = UserRole.Client
            };

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            return await _unitOfWork.Users.LoginAsync(username, password);
        }
    }

}
