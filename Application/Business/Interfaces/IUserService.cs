using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Business.Interfaces
{
    public interface IUserService 
    {
        Task GetByIdAsync(int id);
        Task GetAllAsync();
        Task AddAsync();
        void Update();
        void Delete();
        Task GetAllTicketsByUserIdAsync();


    }
}
