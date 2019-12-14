using Microsoft.EntityFrameworkCore;
using SharedLib.Data;
using SharedLib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharedLib.Services
{
    public class CinematicItemService : ICinematicItemService
    {
        private readonly LibDbContext _context;

        public CinematicItemService(LibDbContext context)
        {
            _context = context;
        }

        public async Task<CinematicItem> Add(CinematicItem cinematicItem)
        {
            _context.CinematicItems.Add(cinematicItem);
            await _context.SaveChangesAsync();
            return cinematicItem;
        }
        
        public async Task<CinematicItem> Delete(int id)
        {
            var cinematicItem = await _context.CinematicItems.FindAsync(id);
            _context.CinematicItems.Remove(cinematicItem);
            await _context.SaveChangesAsync();
            return cinematicItem;
        }

        public async Task<List<CinematicItem>> Get()
        {
            return await _context.CinematicItems.ToListAsync();
        }

        public async Task<CinematicItem> Get(int id)
        {
            var toDo = await _context.CinematicItems.FindAsync(id);
            return toDo;
        }

        public async Task<CinematicItem> Update(CinematicItem cinematicItem)
        {
            _context.Entry(cinematicItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cinematicItem;
        }
    }
}
