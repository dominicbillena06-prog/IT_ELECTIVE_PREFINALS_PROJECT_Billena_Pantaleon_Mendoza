using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Models
{
    [Table("TicketCategories")]
    public class TicketCategory
    {
        [Key]
        public int Id { get; set; }

        public int? ParentCategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [ForeignKey(nameof(ParentCategoryId))]
        public TicketCategory? ParentCategory { get; set; }

        public ICollection<TicketCategory> InverseParentCategory { get; set; } = new List<TicketCategory>();

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}