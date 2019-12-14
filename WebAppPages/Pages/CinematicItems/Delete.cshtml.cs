using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SharedLib.Data;
using SharedLib.Models;

namespace WebAppPages
{
    public class DeleteModel : PageModel
    {
        private readonly SharedLib.Data.LibDbContext _context;

        public DeleteModel(SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CinematicItem CinematicItem { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinematicItem = await _context.CinematicItems.FirstOrDefaultAsync(m => m.Id == id);

            if (CinematicItem == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CinematicItem = await _context.CinematicItems.FindAsync(id);

            if (CinematicItem != null)
            {
                _context.CinematicItems.Remove(CinematicItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
