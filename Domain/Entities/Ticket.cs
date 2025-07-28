using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Ticket : BaseEntitiy
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string? CreatedBy { get; set; }
        public string? Priority { get; set; }
        public string? Status { get; set; } 
        public string? AssignedTo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public ICollection<Comment> TicketComments { get; set; } = new List<Comment>();
        public int UserId { get; set; }
        public User User { get; set; } 

    }


}
