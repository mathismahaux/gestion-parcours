using Infrastructure.EF.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF;

public class GestionParcoursDbContext : DbContext
{
    public GestionParcoursDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<DbPersonne> Personnes { get; set; }
    public DbSet<DbParcours> Parcours { get; set; }
    public DbSet<DbSession> Sessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbPersonne>(entity =>
        {
            entity.ToTable("personnes");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Nom).HasColumnName("nom");
            entity.Property(p => p.Prenom).HasColumnName("prenom");
        });
        
        modelBuilder.Entity<DbParcours>(entity =>
        {
            entity.ToTable("parcours");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Nom).HasColumnName("nom");
            entity.Property(p => p.TempsMarcheMinutes).HasColumnName("temps_marche_minutes");
            entity.Property(p => p.TempsCourseMinutes).HasColumnName("temps_course_minutes");
        });
        
        modelBuilder.Entity<DbSession>(entity =>
        {
            entity.ToTable("sessions");
            entity.HasKey(s => s.Id);
            entity.Property(s => s.PersonneId).HasColumnName("id_personne");
            entity.Property(s => s.ParcoursId).HasColumnName("id_parcours");
            entity.Property(s => s.Type).HasColumnName("type");
            entity.Property(s => s.TempsMinutes).HasColumnName("temps_minutes");
        });
        
        
    }
}