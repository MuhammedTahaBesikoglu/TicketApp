using Application.Business.Interfaces;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repository.Base;
using Domain.Repository.Interface;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Services
{
    public class CommentService : ICommentService
    {
        IRepository<Comment> _repository;
        ITicketRepository _ticketRepository;
        IMapper _mapper;

        public CommentService(IRepository<Comment> repository , IMapper mapper , ITicketRepository ticketRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }
        public async Task<Comment> AddComment(int id , CommentDto dto , int userId)
        {
            var comment = _mapper.Map<Comment>(dto);
            comment.TicketId = id;
            comment.UserId = userId;
            return await _repository.AddAsync(comment);
        }

        public async Task<IEnumerable<Comment>> GetComment(int ticketId)
        {
            return await _ticketRepository.GetComment(ticketId);
        }
    }
}
