using BoletoApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BoletoApi.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<Banco> Bancos { get; set; }
        public DbSet<Boleto> Boletos { get; set; }
    }
}