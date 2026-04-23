using AutoMapper;
using LeadTask.Application.Dtos.Lead;
using LeadTask.Application.Interfaces;
using LeadTask.Domain.Entities;
using LeadTask.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Application.Services
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;
        public LeadService(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<LeadDto> AddLeadAsync(LeadCreateDto leadCreateDto)
        {
            var leadEntity = _mapper.Map<Lead>(leadCreateDto);

            await _leadRepository.AddLeadAsync(leadEntity);
            var leadDto = _mapper.Map<LeadDto>(leadEntity);
            return leadDto;
        }

        public async Task DeleteLeadAsync(int id)
        {

            var leadEntity = await _leadRepository.GetLeadByIdAsync(id);

            if (leadEntity == null)
            {
                throw new Exception($"Lead com id {id} não encontrado.");
            }

            await _leadRepository.DeleteLeadAsync(leadEntity.Id);
        }

        public async Task<IEnumerable<LeadDto>> GetAllLeadsAsync(string? search, string? status)
        {
            var leadEntities = await _leadRepository.GetAllLeadsAsync(search, status);
            var leadDtos = _mapper.Map<IEnumerable<LeadDto>>(leadEntities);
            return leadDtos;
        }

        public async Task<LeadDto> GetLeadByIdAsync(int id)
        {
            var leadEntity = await _leadRepository.GetLeadByIdAsync(id);
            if (leadEntity == null)
            {
                throw new Exception($"Lead com id {id} não encontrado.");
            }
            var leadDto = _mapper.Map<LeadDto>(leadEntity);
            return leadDto;
        }

        public async Task<LeadDto> UpdateLeadAsync(int id, LeadUpdateDto leadUpdateDto)
        {
            var leadEntity = await _leadRepository.GetLeadByIdAsync(id);

            if (leadEntity == null)
            {
                throw new Exception($"Lead com id {id} não encontrado.");
            }
            _mapper.Map(leadUpdateDto, leadEntity);
            await _leadRepository.UpdateLeadAsync(leadEntity);

            var leadReturn = _mapper.Map<LeadDto>(leadEntity);

            return leadReturn;
        }
    }
}
