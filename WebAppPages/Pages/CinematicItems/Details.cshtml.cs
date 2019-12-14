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
    public class DetailsModel : PageModel
    {
        private readonly SharedLib.Data.LibDbContext _context;

        public DetailsModel(SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

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
    }
}
