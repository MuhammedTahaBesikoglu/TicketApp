using Domain.Entities;
using Domain.Repository.Base;
using Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class UserRepository : Repository<User> ,IUserRepository
    {
        ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;

        }

        

    }
}
