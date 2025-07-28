using Application.Business.Interfaces;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using Domain.Repository.Base;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Services
{
    public class TicketService : ITicketService
    {
        ITicketRepository _ticketRepository;
        IRepository<Ticket> _repository;
        IMapper _mapper;
        public TicketService(ITicketRepository ticketRepository, IRepository<Ticket> repository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Ticket> AddAsync(int userId, TicketDto dto, string createdBy)
        {
            var ticket = _mapper.Map<Ticket>(dto);
            ticket.UserId = userId;
            ticket.CreatedBy = createdBy;
            var tickets = await _repository.AddAsync(ticket);

            return tickets;
        }

        public async Task<Ticket> GetTicketById(int userId)
        {
            return await _ticketRepository.GetTicketById(userId);
        }

        public void Update(int id , TicketDto dto)
        {
            var ticket = _repository.GetByIdAsync(id).Result;
            _mapper.Map(dto, ticket);
            _repository.Update(ticket);
        }

        public void Delete(int id)
        {
            var ticket = _repository.GetByIdAsync(id).Result;
            _repository.Delete(ticket);
        }

        
    }
}
