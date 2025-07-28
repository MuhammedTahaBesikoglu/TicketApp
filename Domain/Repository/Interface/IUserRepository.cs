using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository.Base;


namespace Domain.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        
    }
}
