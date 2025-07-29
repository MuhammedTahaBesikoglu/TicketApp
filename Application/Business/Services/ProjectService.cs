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
    public class ProjectService : IProjectService
    {
        IRepository<Project> _repository;
        IProjectRepository _projectRepository;
        IMapper _mapper;

        public ProjectService(IRepository<Project> repository , IMapper mapper , IProjectRepository projectRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task<Project> AddAsync(ProjectDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            return await _repository.AddAsync(project);
        }

        public async Task<Project> AssignToProject(int ticketId, int userId)
        {
            var project = await _projectRepository.AssignToProject(ticketId, userId);
            return project;
        }

        public async Task<IEnumerable<Project>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }
    }
}
