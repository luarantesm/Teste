using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexto
{
    public class ContextAtivo : DbContext
    {
        public ContextAtivo(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextAtivo).Assembly);
        }

        public DbSet<Ativo> Ativo { get; set; }
    }
}