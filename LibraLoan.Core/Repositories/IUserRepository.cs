using LibraLoan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraLoan.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task<List<User>> GetAllAsync();
        Task<User> GetByUserByEmailAndPasswordAsync (string email, string password);
    }
}
