using Kursovaya.Pages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursovaya.Services
{
    public class PadService
    {
        private readonly ApplicationDbContext _context;

        public PadService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SavePadDataAsync(PadBD padData)
        {
            _context.Pads.Add(padData);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PadBD>> GetPadEntriesByDateAndUser(DateTime date, int userId)
        {
            return await _context.Pads
                .Where(p => p.Date == date && p.ID == userId)
                .ToListAsync();
        }
    }
}