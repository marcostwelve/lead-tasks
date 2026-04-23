using LeadTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Domain.Interfaces
{
    public interface ILeadRepository
    {
            Task<IEnumerable<Lead>> GetAllLeadsAsync(string? search, string? status);
            Task<Lead> GetLeadByIdAsync(int id);
            Task AddLeadAsync(Lead lead);
            Task UpdateLeadAsync(Lead lead);
            Task DeleteLeadAsync(int id);
    }
}
