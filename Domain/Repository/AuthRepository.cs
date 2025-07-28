using Domain.Entities;
using Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository.Base;

namespace Domain.Repository
{
    public class AuthRepository : Repository<User>, IAuthRepository
    {
        ApplicationDbContext _context;

        public AuthRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> LoginAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            return user;
        }

        public async Task<User> RegisterAsync(User user)
        {
            await _context.AddAsync(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }
        

        

        
    }
}
