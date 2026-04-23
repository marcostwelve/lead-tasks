using LeadTask.Application.Dtos.TaskItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Application.Interfaces
{
    public interface ITaskItemService
    {
        Task<IEnumerable<TaskDto>> GetAllTasksAsync(int leadId);
        Task<TaskDto> GetTaskByIdAsync(int leadId, int id);
        Task<TaskDto> AddTaskAsync(int leadId, TaskCreateDto taskCreateDto);
        Task<TaskDto> UpdateTaskAsync(int leadId, int id, TaskUpdateDto taskUpdateDto);
        Task DeleteTaskAsync(int leadId, int id);
    }
}
