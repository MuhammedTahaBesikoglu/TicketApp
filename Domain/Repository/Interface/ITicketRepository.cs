using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Repository.Base;

namespace Domain.Repository.Interface
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        public Task<Ticket> GetTicketById(int userId);
        public Task<IEnumerable<Comment>> GetComment(int ticketId);
    }
}
