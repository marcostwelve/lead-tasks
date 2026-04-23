using LeadTask.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Application.Dtos.TaskItem
{
    public record TaskDto(int Id, int LeadId, string Title, DateTime? DueDate, TasksStatus Status, DateTime CreatedAt, DateTime UpdatedAt);
}
