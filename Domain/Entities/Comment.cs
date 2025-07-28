using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comment : BaseEntitiy
    {
        public string? Content { get; set; }
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
