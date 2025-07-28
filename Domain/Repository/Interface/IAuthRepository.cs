using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository.Base;


namespace Domain.Repository.Interface
{
    public interface IAuthRepository : IRepository<User>
    {
        Task<User> RegisterAsync(User user);
        Task<User> LoginAsync(string username , string password);
        Task<User> GetByUsernameAsync(string username);
    }
}
