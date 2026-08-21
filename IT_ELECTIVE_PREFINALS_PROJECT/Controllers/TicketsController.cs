using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IT_ELECTIVE_PREFINALS_PROJECT.Data;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.Tickets
                .AsNoTracking()
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .ToListAsync();

            return View(tickets);
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _context.Tickets
                .AsNoTracking()
                .Include(t => t.Customer)
                .Include(t => t.Category)
                .Include(t => t.Priority)
                .Include(t => t.Status)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null)
            {
                return NotFound();
            }

            var assignments = await _context.TicketAssignments
                .AsNoTracking()
                .Where(a => a.TicketId == id)
                .ToListAsync();

            var assignmentEmpIds = assignments.Select(a => a.EmployeeId).Distinct().ToList();
            var assignmentEmps = await _context.Employees
                .AsNoTracking()
                .Where(e => assignmentEmpIds.Contains(e.Id))
                .ToDictionaryAsync(e => e.Id);

            foreach (var a in assignments)
            {
                if (assignmentEmps.TryGetValue(a.EmployeeId, out var emp))
                    a.Employee = emp;
            }
            ticket.Assignments = assignments;

            var comments = await _context.TicketComments
                .AsNoTracking()
                .Where(c => c.TicketId == id)
                .ToListAsync();

            var commentEmpIds = comments.Select(c => c.EmployeeId).Distinct().ToList();
            var commentEmps = await _context.Employees
                .AsNoTracking()
                .Where(e => commentEmpIds.Contains(e.Id))
                .ToDictionaryAsync(e => e.Id);

            foreach (var c in comments)
            {
                if (commentEmps.TryGetValue(c.EmployeeId, out var emp))
                    c.Employee = emp;
            }
            ticket.Comments = comments;

            ticket.Attachments = await _context.TicketAttachments
                .AsNoTracking()
                .Where(a => a.TicketId == id)
                .ToListAsync();

            var ticketTags = await _context.TicketTags
                .AsNoTracking()
                .Where(tt => tt.TicketId == id)
                .ToListAsync();

            var tagIds = ticketTags.Select(tt => tt.TagId).Distinct().ToList();
            var tags = await _context.Tags
                .AsNoTracking()
                .Where(t => tagIds.Contains(t.Id))
                .ToDictionaryAsync(t => t.Id);

            foreach (var tt in ticketTags)
            {
                if (tags.TryGetValue(tt.TagId, out var tag))
                    tt.Tag = tag;
            }
            ticket.TicketTags = ticketTags;

            return View(ticket);
        }
    }
}