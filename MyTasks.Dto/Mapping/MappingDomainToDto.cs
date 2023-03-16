using AutoMapper;
using MyTasks.Domain.Entities;
using MyTasks.Dto.Dto;

namespace MyTasks.Dto.Mapping
{
    public class MappingDomainToDto : Profile
    {
        public MappingDomainToDto()
        {
            CreateMap<MyTask, MyTasksDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<LogError, LogErrorDto>().ReverseMap();
        }
    }
}
