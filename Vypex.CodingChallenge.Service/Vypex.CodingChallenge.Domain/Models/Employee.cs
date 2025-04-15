using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vypex.CodingChallenge.Domain.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public List<LeaveDay>? Leaves { get; set; } = new();
        [NotMapped]
        public int TotalLeaveDays => Leaves?.Sum(ld => (ld.EndDate - ld.StartDate).Days + 1) ?? 0;
    }
}
