using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;


namespace Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => "Employee"));
            CreateMap<TicketDto, Ticket>().ReverseMap();
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<ProjectDto, Project>().ReverseMap();

        }
    }
}
