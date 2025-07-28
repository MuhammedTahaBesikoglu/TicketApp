using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Domain.Entities;

namespace Application.Business.Interfaces
{
    public interface ICommentService
    {
        Task<Comment> AddComment(int id , CommentDto dto , int userId);
        Task<IEnumerable<Comment>> GetComment(int ticketId);
    }
}
