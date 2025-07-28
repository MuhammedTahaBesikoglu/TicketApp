using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Interfaces
{
    public interface ITicketService
    {
        public Task<Ticket> AddAsync(int userId , TicketDto dto , string createdBy);
        
        public Task<Ticket> GetTicketById(int userId);
        public void Update(int id , TicketDto dto);
        public void Delete(int id);

    }
}
