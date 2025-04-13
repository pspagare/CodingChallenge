using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vypex.CodingChallenge.Domain.Models
{
    public class LeaveDay
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // Foreign Key
        public Guid EmployeeId { get; set; }
        // Navigation Property
        public Employee Employee { get; set; } = null!;
    }
}
