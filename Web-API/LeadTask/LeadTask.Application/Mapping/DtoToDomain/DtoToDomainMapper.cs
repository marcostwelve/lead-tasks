using AutoMapper;
using LeadTask.Application.Dtos.Lead;
using LeadTask.Application.Dtos.TaskItem;
using LeadTask.Domain.Entities;

namespace LeadTask.Application.Mapping.DtoToDomain
{
    public class DtoToDomainMapper : Profile
    {
        public DtoToDomainMapper()
        {
            CreateMap<LeadCreateDto, Lead>();
            CreateMap<LeadUpdateDto, Lead>();
            CreateMap<LeadDto, Lead>();

            CreateMap<TaskCreateDto, TaskItem>();
            CreateMap<TaskUpdateDto, TaskItem>();
            CreateMap<TaskDto, TaskItem>();
        }
    }
}
