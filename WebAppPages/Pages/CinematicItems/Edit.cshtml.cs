using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SharedLib.Data;
using SharedLib.Models;

namespace WebAppPages
{
    public class EditModel : PageModel
    {
        private readonly SharedLib.Data.LibDbContext _context;

        public EditModel(SharedLib.Data.LibDbContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CinematicItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinematicItemExists(CinematicItem.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CinematicItemExists(int id)
        {
            return _context.CinematicItems.Any(e => e.Id == id);
        }
    }
}
