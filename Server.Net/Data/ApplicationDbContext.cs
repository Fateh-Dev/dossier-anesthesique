using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Net;

namespace Server.Net.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public virtual DbSet<Patient> Patients { get; set; }
    public virtual DbSet<Medecin> Medecins { get; set; }
    public virtual DbSet<Consultation> Consultations { get; set; }
    public virtual DbSet<ExaminClinique> ExaminsCliniques { get; set; }
    public virtual DbSet<ConsigneAnesthesique> ConsignesAnesthesiques { get; set; }
    public virtual DbSet<AgentAnesthesique> AgentsAnesthesiques { get; set; }
    public virtual DbSet<ActeurIntervenant> ActeursIntervenants { get; set; }
    public virtual DbSet<BilanInOut> BilanInOut { get; set; }
    public virtual DbSet<DeroulementOperatoire> DeroulementsOperatoire { get; set; }
    public virtual DbSet<Intervention> Interventions { get; set; }
    public virtual DbSet<PostOperation> PostsOperation { get; set; }
    public virtual DbSet<ProblemePreOperatoire> ProblemesPreOperatoire { get; set; }
    public virtual DbSet<ResumeOperation> ResumeOperation { get; set; }

    public virtual DbSet<AntecedentMedical> AntecedentsMedicaux { get; set; }
    public virtual DbSet<AntecedentChirurgical> AntecedentsChirurgicaux { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }
    public virtual DbSet<Agent> Agents { get; set; }
    public virtual DbSet<TypeAnesthesie> TypesAnesthesies { get; set; }
    public virtual DbSet<Respirateur> Respirateurs { get; set; }
    public virtual DbSet<GradeScientifique> GradesScientifiques { get; set; }
    public virtual DbSet<Specialite> Specialites { get; set; }
    public virtual DbSet<Arme> Armes { get; set; }
    public virtual DbSet<AppSetting> AppSettings { get; set; }
    public virtual DbSet<AppNotification> AppNotifications { get; set; }
    public virtual DbSet<ExternalEntity> ExternalEntities { get; set; }

    // Dossier Medical
    public virtual DbSet<DMSI_Dossiers_Medicaux> DMSI_Dossiers_Medicaux { get; set; }
    public DbSet<DMSI_Metrics_Admission> DMSI_Metrics_Admission { get; set; }
    public DbSet<DMSI_Examins_Complementaires> DMSI_Examins_Complementaires { get; set; }
    public DbSet<DMSI_Antecedents> DMSI_Antecedents { get; set; }
    public DbSet<DMSI_Traitements_Encours> DMSI_Traitements_Encours { get; set; }
    public DbSet<DMSI_Examins_Cliniques> DMSI_Examins_Cliniques { get; set; }
    public DbSet<DMSI_Evolutions> DMSI_Evolutions { get; set; }
    public DbSet<DMSI_Conduite> DMSI_Conduites { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DMSI_Antecedents>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
            entity
                .HasOne(e => e.Dossier)
                .WithMany(s => s.Antecedents)
                .HasForeignKey(e => e.DMSI_Dossiers_MedicauxId)
                .OnDelete(DeleteBehavior.Cascade);
            ;
        });
        modelBuilder.Entity<DMSI_Dossiers_Medicaux>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<DMSI_Evolutions>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
            entity
                .HasOne(e => e.Dossier)
                .WithMany(s => s.Evolutions)
                .HasForeignKey(e => e.DMSI_Dossiers_MedicauxId)
                .OnDelete(DeleteBehavior.Cascade);
            ;
        });
        modelBuilder.Entity<DMSI_Conduite>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
            // Configure one-to-one relationship
            entity
                .HasOne(e => e.Dossier)
                .WithOne(s => s.DMSI_Conduite)
                .HasForeignKey<DMSI_Conduite>(e => e.IdDossier)
                .OnDelete(DeleteBehavior.Cascade); // Foreign key in DMSI_Conduite
        });
        modelBuilder.Entity<DMSI_Examins_Cliniques>(entity =>
        {
            //    entity.HasOne(e => e.Dossier)
            //                               .WithMany()
            //                               .HasForeignKey(e => e.Dossier);
        });
        modelBuilder.Entity<DMSI_Metrics_Admission>(entity => { });
        modelBuilder.Entity<DMSI_Examins_Complementaires>(entity => { });
        modelBuilder.Entity<DMSI_Traitements_Encours>(entity => { });

        modelBuilder.Entity<Medecin>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<Intervention>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<AntecedentChirurgical>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<AntecedentMedical>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<ExaminClinique>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<ActeurIntervenant>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<ConsigneAnesthesique>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<BilanInOut>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<PostOperation>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<ProblemePreOperatoire>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<ResumeOperation>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        base.OnModelCreating(modelBuilder);
    }
}
