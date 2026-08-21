using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketAssignments")]
    public class TicketAssignment
    {
        public int TicketId { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public string AssignedAt { get; set; } = string.Empty;

        public string? UnassignedAt { get; set; }

        public long IsPrimary { get; set; } = 0;

        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; } = null!;

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; } = null!;
    }
}
