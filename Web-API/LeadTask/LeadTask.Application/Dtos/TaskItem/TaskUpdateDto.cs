using LeadTask.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Application.Dtos.TaskItem
{
    public record TaskUpdateDto(string Title, DateTime? DueDate, TasksStatus Status);
}
