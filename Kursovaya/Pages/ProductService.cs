using Kursovaya.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kursovaya.Services
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<PaxdBD>> GetProductsAsync()
        {
            return await _context.Paxds.ToListAsync();
        }

        public async Task<PaxdBD> GetProductById(int productId)
        {
            return await _context.Paxds.FindAsync(productId);
        }
    }
}
