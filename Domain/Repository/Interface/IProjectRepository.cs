using Domain.Entities;
using Domain.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Interface
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project> AssignToProject(int projectId, int ticketId);
    }
}
