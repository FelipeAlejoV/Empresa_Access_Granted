using Microsoft.EntityFrameworkCore;
using Empresa_Access_Granted.Models;

namespace Empresa_Access_Granted.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>()
            .ToTable("Cliente")
            .HasKey(c => c.Id);
        
        base.OnModelCreating(modelBuilder);
    }
    public DbSet<Cliente> Clientes { get; set; }
    
}