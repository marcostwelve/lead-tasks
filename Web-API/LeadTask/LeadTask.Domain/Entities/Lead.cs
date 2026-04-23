using LeadTask.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "O nome deve conter pelo menos 3 caracteres")]
        public string Name { get; set; } = null!;
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = null!;
        public LeadStatus Status { get; set; } = LeadStatus.New;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
        public bool isDeleted { get; set; } = false;
    }
}
