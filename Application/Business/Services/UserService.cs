using Application.Business.Interfaces;
using Domain.Entities;
using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Services
{
    public  class UserService : IUserService
    {
        IUserRepository _userRepository; 
        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task GetByIdAsync(int id)
        {
            return ;
            
        }

        public async Task AddAsync()
        {
           
            return;
        }

        public void Delete()
        {
            
        }
        public void Update()
        {
            
        }

        public Task GetAllAsync()
        {
            var entity = _userRepository.GetAllAsync();
            return entity;
        }

        

        public async Task GetAllTicketsByUserIdAsync()
        {
            
            
        }

        //public Task AssignedToAgent()
        //{

        //}

        public Ticket TicketSettings(Ticket ticket , int userId , string createdBy)
        {
            ticket.UserId = userId;
            ticket.Status = "Open";
            ticket.CreatedBy = createdBy;
            return ticket;
        }

        


        
    }
}
