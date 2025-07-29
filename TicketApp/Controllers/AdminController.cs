using Application.Business.Interfaces;
using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IProjectService _projectService;

        public AdminController(IProjectService projectService) 
        {
            _projectService = projectService;
        }

        [HttpGet("Projects")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetProjects()
        {
            var projects = _projectService.GetAllAsync().Result.ToList();
            if (projects == null || projects.Count == 0)
            {
                return NotFound("Proje bulunamadı.");
            }

            return Ok(projects);
        }
        [HttpPost("Projects")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddProject(ProjectDto dto)
        {
            var project = _projectService.AddAsync(dto).Result;  
            if (project == null)
            {
                return BadRequest("Proje oluşturulamadı.");
            }

            return Ok("Proje oluşturuldu.\n" + project);
        }

        [HttpPost("Assign-Projects")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignToProject(int ticketId, int projectId)
        {
            var project = await _projectService.AssignToProject(ticketId, projectId);
            if (project == null)
            {
                return BadRequest("Proje ataması yapılamadı.");
            }

            return Ok(project);
        }
    }
}
