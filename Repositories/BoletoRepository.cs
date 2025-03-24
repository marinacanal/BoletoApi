using BoletoApi.Data;
using BoletoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoApi.Repositories
{
    public class BoletoRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Boleto> _dbSet;

        public BoletoRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Boleto>(); 
        }

        // create
        public async Task<Boleto> CriarBoleto(Boleto boleto) {
            await _dbSet.AddAsync(boleto);
            await _context.SaveChangesAsync(); 
            return boleto;  
        } 

        // get by id
        public async Task<Boleto> BuscarBoletoPorId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }  
    }
}