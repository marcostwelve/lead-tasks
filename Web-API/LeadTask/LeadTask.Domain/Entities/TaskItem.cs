using LeadTask.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadTask.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime? DueDate { get; set; }
        public TasksStatus Status { get; set; } = TasksStatus.Todo;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public Lead? Lead { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
