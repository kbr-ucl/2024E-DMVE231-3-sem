using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorDemo.Database;

namespace RazorDemo.Pages.People;

public class EditModel : PageModel
{
    private readonly DemoContext _context;

    public EditModel(DemoContext context)
    {
        _context = context;
    }

    [BindProperty] public Person Person { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) return NotFound();

        var person = await _context.People.FirstOrDefaultAsync(m => m.Id == id);
        if (person == null) return NotFound();
        Person = person;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more information, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        _context.Attach(Person).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonExists(Person.Id))
                return NotFound();
            throw;
        }

        return RedirectToPage("./Index");
    }

    private bool PersonExists(int id)
    {
        return _context.People.Any(e => e.Id == id);
    }
}