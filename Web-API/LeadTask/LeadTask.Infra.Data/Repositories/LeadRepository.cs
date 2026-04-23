using LeadTask.Domain.Entities;
using LeadTask.Domain.Helpers.Enums;
using LeadTask.Domain.Interfaces;
using LeadTask.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Infra.Data.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly AppDbContext _context;
        public LeadRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddLeadAsync(Lead lead)
        {
            await _context.Leads.AddAsync(lead);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLeadAsync(int id)
        {
            var lead = await _context.Leads.FirstOrDefaultAsync(l => l.Id == id);
            if (lead != null)
            {
                lead.isDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Lead>> GetAllLeadsAsync(string? search, string? status)
        {
            IQueryable<Lead> query = _context.Leads.Include(t => t.Tasks).Where(l => !l.isDeleted).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(l => l.Name.Contains(search) || l.Email.Contains(search));
            }

            if (Enum.TryParse<LeadStatus>(status, true, out var parsedStatus))
            {
                query = query.Where(l => l.Status == parsedStatus);
            }

            var leads = await query.AsNoTracking().ToListAsync();
            return leads;
        }

        public async Task<Lead> GetLeadByIdAsync(int id)
        {
            var lead = await _context.Leads.Include(t => t.Tasks).FirstOrDefaultAsync(l => l.Id == id && !l.isDeleted);
            return lead;
        }

        public async Task UpdateLeadAsync(Lead lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }
    }
}
