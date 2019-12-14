using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SharedLib.Data;
using SharedLib.Models;

namespace WebAppMvc.Controllers
{
    public class CinematicItemsController : Controller
    {
        private readonly LibDbContext _context;

        public CinematicItemsController(LibDbContext context)
        {
            _context = context;
        }

        // GET: CinematicItems
        public async Task<IActionResult> Index()
        {
            return View(await _context.CinematicItems.ToListAsync());
        }

        // GET: CinematicItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinematicItem = await _context.CinematicItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinematicItem == null)
            {
                return NotFound();
            }

            return View(cinematicItem);
        }

        // GET: CinematicItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CinematicItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Phase,ReleaseDate")] CinematicItem cinematicItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cinematicItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cinematicItem);
        }

        // GET: CinematicItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinematicItem = await _context.CinematicItems.FindAsync(id);
            if (cinematicItem == null)
            {
                return NotFound();
            }
            return View(cinematicItem);
        }

        // POST: CinematicItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Phase,ReleaseDate")] CinematicItem cinematicItem)
        {
            if (id != cinematicItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cinematicItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CinematicItemExists(cinematicItem.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cinematicItem);
        }

        // GET: CinematicItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cinematicItem = await _context.CinematicItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cinematicItem == null)
            {
                return NotFound();
            }

            return View(cinematicItem);
        }

        // POST: CinematicItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cinematicItem = await _context.CinematicItems.FindAsync(id);
            _context.CinematicItems.Remove(cinematicItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CinematicItemExists(int id)
        {
            return _context.CinematicItems.Any(e => e.Id == id);
        }
    }
}
