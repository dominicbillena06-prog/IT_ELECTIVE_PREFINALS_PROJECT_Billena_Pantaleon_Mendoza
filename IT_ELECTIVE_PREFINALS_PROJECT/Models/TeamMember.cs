using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TeamMembers")]
    public class TeamMember
    {
        public int TeamId { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public string JoinedAt { get; set; } = string.Empty;

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; } = null!;
    }
}