using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NT_TECH.Areas.Identity.Data;
using NT_TECH.Models.Veiculos;

namespace NT_TECH.Data;

public class NT_TECHContext : IdentityDbContext<NT_TECHUser>
{
    public NT_TECHContext(DbContextOptions<NT_TECHContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
    }

    public DbSet<NT_TECH.Models.Veiculos.Veiculos> Veiculos { get; set; } = default!;

    public DbSet<NT_TECH.Models.Veiculos.PlacasCadastradas> PlacasCadastradas { get; set; } = default!;
}
