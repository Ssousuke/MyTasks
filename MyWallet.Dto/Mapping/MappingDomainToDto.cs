using AutoMapper;
using MyWallet.Domain.Entities;
using MyWallet.Dto.Dto;

namespace MyWallet.Dto.Mapping
{
    public class MappingDomainToDto : Profile
    {
        public MappingDomainToDto()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<LogError, LogErrorDto>().ReverseMap();
        }
    }
}
