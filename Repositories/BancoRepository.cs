using BoletoApi.Data;
using BoletoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoApi.Repositories
{
    public class BancoRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Banco> _dbSet;

        public BancoRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Banco>(); 
        }
        
        // create
        public async Task<Banco> CriarBanco(Banco banco)
        {
            await _dbSet.AddAsync(banco);
            await _context.SaveChangesAsync();
            return banco;
        }

        // get by id
        public async Task<Banco> BuscarBancoPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        // get all
        public async Task<List<Banco>> BuscarTodosBancos()
        {
            return await _dbSet.ToListAsync();
        }
    }
}