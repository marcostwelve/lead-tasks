using LeadTask.Domain.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadTask.Application.Dtos.Lead
{
    public record LeadCreateDto(string Name, string Email, LeadStatus? Status);
}
