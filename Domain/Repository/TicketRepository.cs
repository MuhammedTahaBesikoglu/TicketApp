using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository.Interface;
using Domain.Entities;
using Domain.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class TicketRepository : Repository<Ticket> , ITicketRepository
    {
        ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context ) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetComment(int ticketId)
        {
            var comments = await _context.Comments.Where(c => c.TicketId == ticketId).ToListAsync();
            return comments;
        }

        public async Task<Ticket> GetTicketById(int userId)
        {
            var ticket = _context.Tickets.FirstOrDefault(t => t.UserId == userId);
            return ticket;
        }

        
    }
}
