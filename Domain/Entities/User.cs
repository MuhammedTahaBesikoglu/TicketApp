using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntitiy
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string Role { get; set; } 

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<Comment> TicketComments { get; set; } = new List<Comment>();
    }
}
