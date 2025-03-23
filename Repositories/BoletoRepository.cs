using BoletoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoApi.Repositories
{
    public class BoletoRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Boleto> _dbSet;

        public BoletoRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Boleto>(); 
        }

        // get by id
        public async Task<Boleto> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        // create
        public async Task<Boleto> CreateAsync(Boleto boleto) {
            await _dbSet.AddAsync(boleto);
            await _context.SaveChangesAsync(); 
            return boleto;  
        }   
    }
}