using LeadTask.Application.Dtos.Lead;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Application.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadDto>> GetAllLeadsAsync(string? search, string? status);
        Task<LeadDto> GetLeadByIdAsync(int id);
        Task<LeadDto> AddLeadAsync(LeadCreateDto leadCreateDto);
        Task<LeadDto> UpdateLeadAsync(int id, LeadUpdateDto leadUpdateDto);
        Task DeleteLeadAsync(int id);
    }
}
