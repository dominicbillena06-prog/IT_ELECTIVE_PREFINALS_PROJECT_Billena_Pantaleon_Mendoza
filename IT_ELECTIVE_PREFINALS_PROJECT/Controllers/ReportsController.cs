using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> EmployeeWorkload()
        {
            var workload = await _context.Employees
                .Where(e => e.IsActive == 1)
                .Select(e => new
                {
                    EmployeeName = e.FirstName + " " + e.LastName,
                    UnresolvedTickets = e.TicketAssignments
                        .Count(a => a.UnassignedAt == null && a.Ticket.Status.IsClosed == 0)
                })
                .AsNoTracking()
                .ToListAsync();

            return View(workload);
        }


        public async Task<IActionResult> DepartmentWorkload()
        {
            var workload = await _context.Departments
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    EmployeeCount = d.Employees.Count,
                    UnresolvedTickets = d.Employees
                        .SelectMany(e => e.TicketAssignments)
                        .Count(a => a.UnassignedAt == null && a.Ticket.Status.IsClosed == 0)
                })
                .AsNoTracking()
                .ToListAsync();

            return View(workload);
        }

        public async Task<IActionResult> UnassignedTickets()
        {
            var tickets = await _context.Tickets
                .Where(t => !t.Assignments.Any(a => a.UnassignedAt == null))
                .Include(t => t.Customer)
                .Include(t => t.Status)
                .AsNoTracking()
                .ToListAsync();

            return View(tickets);
        }


        public async Task<IActionResult> MultipleAssignees()
        {
            var tickets = await _context.Tickets
                .Where(t => t.Assignments.Count(a => a.UnassignedAt == null) > 1)
                .Include(t => t.Customer)
                .Include(t => t.Assignments)
                    .ThenInclude(a => a.Employee)
                .AsNoTracking()
                .ToListAsync();

            return View(tickets);
        }


        public async Task<IActionResult> PrimaryAssignees()
        {
            var tickets = await _context.Tickets
                .Include(t => t.Assignments)
                    .ThenInclude(a => a.Employee)
                .AsNoTracking()
                .ToListAsync();

            return View(tickets);
        }
    }
}