using Application.DTOs;
using Application.Business.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using AutoMapper;
using Application.Business.Services;


namespace TicketApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        ITicketService _ticketService;
        ICommentService _commentService;
        IMapper _mapper;

        public TicketController(ITicketService ticketService, IMapper mapper, ICommentService commentService)
        {
            _ticketService = ticketService;
            _mapper = mapper;
            _commentService = commentService;
        }

        [HttpPost("Tickets")]
        [Authorize(Roles = "Employee")]

        public async Task<IActionResult> CreateTicket([FromBody] TicketDto Dto)
        {
            // Validation eklemeyi dusunebilirsin...

            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var createdBy = User.FindFirst(ClaimTypes.Name).Value;


            var ticket = await _ticketService.AddAsync(userId, Dto, createdBy);
            if (ticket == null)
            {
                return BadRequest("Ticket oluşturulamadı");
            }

            return Ok(ticket);

        }

        [HttpGet("Tickets")]
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> GetAllTicket()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var ticket = await _ticketService.GetTicketById(userId);
            if (ticket == null)
            {
                return NotFound("Görev bulunamadı.");
            }


            return Ok(ticket);
        }

        [HttpPut("Tickets/{id}")]
        [Authorize(Roles = "Employee")]
        public IActionResult UpdateTicket(int id, [FromBody] TicketDto Dto)
        {
            // Validation eklemeyi dusunebilirsin...

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _ticketService.Update(id, Dto);
            var ticket = _ticketService.GetTicketById(userId).Result;

            return Ok(new { Message = "Görev başarıyla güncellendi.", ticket });
        }

        [HttpDelete("Tickets/{id}")]
        [Authorize(Roles = "Employee")]

        public IActionResult DeleteTicket(int id)
        {
            _ticketService.Delete(id);

            return Ok("Görev başarıyla silindi.");
        }

        [HttpPost("tickets-comment/{id}")]

        public IActionResult AddComment(int id, CommentDto dto)
        {
            // Validation eklemeyi dusunebilirsin...

            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var comment = _commentService.AddComment(id, dto, userId);
            if (comment == null)
            {
                return BadRequest("Yorum eklenemedi.");
            }

            return Ok(new { Message = "Yorum başarıyla eklendi." });
        }

        [HttpGet("tickets-comment/{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var comments = await _commentService.GetComment(id);
            if (comments == null)
            {
                return NotFound("Yorum yapılmamış.");
            }

            return Ok(comments);

        }
    }
    
}
