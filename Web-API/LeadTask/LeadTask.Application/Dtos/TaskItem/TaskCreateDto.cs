
using LeadTask.Domain.Helpers.Enums;

namespace LeadTask.Application.Dtos.TaskItem
{
    public record TaskCreateDto(string Title, DateTime? DueDate, TasksStatus? Status);
}
