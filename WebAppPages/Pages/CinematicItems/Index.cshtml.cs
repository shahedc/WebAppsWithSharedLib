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
    public class IndexModel : PageModel
    {
        private readonly SharedLib.Data.LibDbContext _context;

        public IndexModel(SharedLib.Data.LibDbContext context)
        {
            _context = context;
        }

        public IList<CinematicItem> CinematicItem { get;set; }

        public async Task OnGetAsync()
        {
            CinematicItem = await _context.CinematicItems.ToListAsync();
        }
    }
}
