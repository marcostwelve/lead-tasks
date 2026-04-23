using LeadTask.Domain.Entities;
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
    public class TaskItemRepository : ITaskItemRespository
    {
        private readonly AppDbContext _context;
        public TaskItemRepository(AppDbContext context) 
        {
            _context = context;
        }
        public async Task AddTaskAsync(int leadId, TaskItem task)
        {
            task.LeadId = leadId;
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(int leadId, int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id && x.LeadId == leadId);
            task.isDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskItem>> GetAllTasksAsync(int leadId)
        {
            var tasks =  await _context.Tasks.Where(t => t.LeadId == leadId && !t.isDeleted).ToListAsync();
            return tasks;
        }

        public async Task<TaskItem> GetTaskByIdAsync(int leadId, int id)
        {
            var task = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id && x.LeadId == leadId && !x.isDeleted);
            return task;
        }

        public async Task UpdateTaskAsync(int leadId, TaskItem task)
        {
            if (task.LeadId != leadId)
            {
                throw new ArgumentException("A tarefa não pertence ao lead especificado.");
            } 
            task.LeadId = leadId;
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
        }
    }
}
