using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketTags")]
    public class TicketTag
    {
        public int TicketId { get; set; }

        public int TagId { get; set; }

        [ForeignKey(nameof(TicketId))]
        public Ticket Ticket { get; set; } = null!;

        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; } = null!;
    }
}