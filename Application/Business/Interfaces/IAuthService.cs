using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Interfaces
{
    public interface IAuthService 
    {
        Task RegisterAsync(RegisterDto dto);
        Task<User> LoginAsync(string username , string password);
        Task<User> GetByUsernameAsync(string username);
    }
}
