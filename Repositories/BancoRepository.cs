using BoletoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoApi.Repositories
{
    public class BancoRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Banco> _dbSet;

        public BancoRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Banco>(); 
        }
        
        // get by id
        public async Task<Banco> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        // get all
        public async Task<List<Banco>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        // create
        public async Task CreateAsync(Banco banco)
        {
            await _dbSet.AddAsync(banco);
            await _context.SaveChangesAsync();
        }
    }
}