using AutoMapper;
using LeadTask.Application.Dtos.Lead;
using LeadTask.Application.Dtos.TaskItem;
using LeadTask.Domain.Entities;

namespace LeadTask.Application.Mapping.DomainToDto
{
    public class DomainToDtoMapper : Profile
    {
        public DomainToDtoMapper()
        {
            CreateMap<Lead, LeadDto>();
            CreateMap<Lead, LeadUpdateDto>();
            CreateMap<Lead, LeadCreateDto>();

            CreateMap<TaskItem, TaskDto>();
            CreateMap<TaskItem, TaskUpdateDto>();
            CreateMap<TaskItem, TaskCreateDto>();
        }
    }
}
