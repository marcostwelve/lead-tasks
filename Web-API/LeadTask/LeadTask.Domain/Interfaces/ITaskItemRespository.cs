using LeadTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Domain.Interfaces
{
    public interface ITaskItemRespository
    {
        Task<IEnumerable<TaskItem>> GetAllTasksAsync(int leadId);
        Task<TaskItem> GetTaskByIdAsync(int leadId, int id);
        Task AddTaskAsync(int leadId, TaskItem task);
        Task UpdateTaskAsync(int leadId, TaskItem task);
        Task DeleteTaskAsync(int leadId, int id);
    }
}
