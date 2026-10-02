using Microsoft.EntityFrameworkCore;
using Pagin_Web_Zoonosis.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Dueno> Duenos { get; set; }
    public DbSet<Mascota> Mascotas { get; set; }
    public DbSet<DuenoMascota> DuenoMascotas { get; set; }
    public DbSet<Ficha> Fichas { get; set; }
    public DbSet<Historial> Historiales { get; set; }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<DuenoMascota>(e =>
        {
            e.HasKey(x => new { x.IDdueño, x.IDmascota });
            e.HasOne(x => x.Dueno).WithMany(d => d.DuenoMascotas)
             .HasForeignKey(x => x.IDdueño).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(x => x.Mascota).WithMany(m => m.DuenoMascotas)
             .HasForeignKey(x => x.IDmascota).OnDelete(DeleteBehavior.Cascade);
        });

        mb.Entity<Ficha>(e =>
        {
            e.HasOne(f => f.Mascota).WithMany(m => m.Fichas)
             .HasForeignKey(f => f.IDmascota).OnDelete(DeleteBehavior.Cascade);
            e.HasOne(f => f.Dueno).WithMany()
             .HasForeignKey(f => f.IDdueño).OnDelete(DeleteBehavior.SetNull);
            e.HasOne(f => f.Veterinario).WithMany()
             .HasForeignKey(f => f.IDveterinario).OnDelete(DeleteBehavior.SetNull);
            e.HasQueryFilter(f => !f.Eliminada); // las fichas "borradas" se ocultan solas
        });

        mb.Entity<Usuario>().HasIndex(u => u.Email).IsUnique();
    }
}