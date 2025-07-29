using Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Repository.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository
{
    public class ProjectRepository : Repository<Project> , IProjectRepository
    {
        ApplicationDbContext _context;
        public ProjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Project> AssignToProject(int ticketId, int projectId)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(t => t.Id == ticketId);
            ticket.ProjectId = projectId;
            
            var assignTickets = await _context.Tickets.Where(t => t.ProjectId == projectId).ToListAsync();
            var projects = await _context.Projects.FindAsync(projectId);
            for(int i = 0; i < assignTickets.Count; i++)
            {
                projects.Tickets.Add(assignTickets[i]);
            }
            _context.SaveChanges();
            return projects;
        }
    }
}
