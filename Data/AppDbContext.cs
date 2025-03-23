using BoletoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
    }
}