using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorDemo.Database;

namespace RazorDemo.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly DemoContext _context;

        public IndexModel(DemoContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Person = await _context.People.ToListAsync();
        }
    }
}
