using IT_ELECTIVE_PREFINALS_PROJECT.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<TeamMember> TeamMembers => Set<TeamMember>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<TicketAssignment> TicketAssignments => Set<TicketAssignment>();
        public DbSet<TicketAttachment> TicketAttachments => Set<TicketAttachment>();
        public DbSet<TicketCategory> TicketCategories => Set<TicketCategory>();
        public DbSet<TicketComment> TicketComments => Set<TicketComment>();
        public DbSet<TicketPriority> TicketPriorities => Set<TicketPriority>();
        public DbSet<TicketStatus> TicketStatuses => Set<TicketStatus>();
        public DbSet<TicketTag> TicketTags => Set<TicketTag>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Key Mappings

            modelBuilder.Entity<TeamMember>()
                .HasKey(tm => new { tm.TeamId, tm.EmployeeId });

            modelBuilder.Entity<TicketTag>()
                .HasKey(tt => new { tt.TicketId, tt.TagId });
        }
    }
}