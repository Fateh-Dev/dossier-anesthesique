using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Net;
using Server.Net.Models.Anesthesia;
using Server.Net.Models.Antecedents;
using Server.Net.Models.DMSI;
using Server.Net.Models.Entities;
using Server.Net.Models.Operations;
using Server.Net.Models.Reference;
using Server.Net.Models.System;

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
    public virtual DbSet<ExternalEntity> ExternalEntities { get; set; }
    public virtual DbSet<Default> Defaults { get; set; }

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
        // ========================================
        // DMSI (Dossier Medical) Entities
        // ========================================

        modelBuilder.Entity<DMSI_Dossiers_Medicaux>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);

            // Indexes for performance
            entity.HasIndex(e => e.PatientId);
            entity.HasIndex(e => e.MedecinId);
            entity.HasIndex(e => e.DateAdmission);
        });

        modelBuilder.Entity<DMSI_Antecedents>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);

            entity
                .HasOne(e => e.Dossier)
                .WithMany(s => s.Antecedents)
                .HasForeignKey(e => e.DMSI_Dossiers_MedicauxId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.DMSI_Dossiers_MedicauxId);
        });

        modelBuilder.Entity<DMSI_Evolutions>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);

            entity
                .HasOne(e => e.Dossier)
                .WithMany(s => s.Evolutions)
                .HasForeignKey(e => e.DMSI_Dossiers_MedicauxId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.DMSI_Dossiers_MedicauxId);
        });

        modelBuilder.Entity<DMSI_Conduite>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);

            // Configure one-to-one relationship
            entity
                .HasOne(e => e.Dossier)
                .WithOne(s => s.DMSI_Conduite)
                .HasForeignKey<DMSI_Conduite>(e => e.IdDossier)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.IdDossier);
        });

        modelBuilder.Entity<DMSI_Examins_Cliniques>(entity =>
        {
            // Note: Doesn't inherit from FullAuditedEntity - no soft delete
            entity
                .HasOne(e => e.Dossier)
                .WithOne(s => s.Examins_Cliniques)
                .HasForeignKey<DMSI_Examins_Cliniques>(e => e.DossierId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.DossierId);
        });

        modelBuilder.Entity<DMSI_Metrics_Admission>(entity =>
        {
            // Note: Doesn't inherit from FullAuditedEntity - no soft delete
            entity
                .HasOne(e => e.Dossier)
                .WithOne(s => s.A_Admission)
                .HasForeignKey<DMSI_Metrics_Admission>(e => e.DossierId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.DossierId);
        });

        modelBuilder.Entity<DMSI_Examins_Complementaires>(entity =>
        {
            // Note: Doesn't inherit from FullAuditedEntity - no soft delete
            entity
                .HasOne(e => e.Dossier)
                .WithOne(s => s.Examins_Complementaires)
                .HasForeignKey<DMSI_Examins_Complementaires>(e => e.DossierId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.DossierId);
        });

        modelBuilder.Entity<DMSI_Traitements_Encours>(entity =>
        {
            // Note: Doesn't inherit from FullAuditedEntity - no soft delete
            entity
                .HasOne(e => e.Dossier)
                .WithMany(s => s.Traitements)
                .HasForeignKey(e => e.DossierId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(e => e.DossierId);
        });

        // ========================================
        // Core Domain Entities
        // ========================================

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);

            // Unique index on Matricule
            entity.HasIndex(e => e.Matricule).IsUnique();
        });

        modelBuilder.Entity<Medecin>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);

            // Indexes for foreign keys and queries
            entity.HasIndex(e => e.PatientId);
            entity.HasIndex(e => e.MedecinId);
            entity.HasIndex(e => e.DateConsultation);
        });

        modelBuilder.Entity<Intervention>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);

            // Indexes for foreign keys and dashboard queries
            entity.HasIndex(e => e.ConsultationId);
            entity.HasIndex(e => e.Date);
            entity.HasIndex(e => new { e.Date, e.Status }); // Composite index
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

        modelBuilder.Entity<ConsigneAnesthesique>(entity =>
        {
            entity.HasQueryFilter(m => m.IsDeleted == false);
        });

        // ========================================
        // Intervention Related Entities
        // ========================================

        modelBuilder.Entity<ActeurIntervenant>(entity =>
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

        modelBuilder.Entity<DeroulementOperatoire>(entity =>
        {
            // Note: Doesn't inherit from FullAuditedEntity - no soft delete
        });

        modelBuilder.Entity<AgentAnesthesique>(entity =>
        {
            // Note: Doesn't inherit from FullAuditedEntity - no soft delete
        });

        // ========================================
        // Reference Data / Lookup Entities
        // ========================================

        modelBuilder.Entity<Grade>(entity =>
        {
            // Note: Doesn't inherit from FullAuditedEntity - no soft delete
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        // Note: The following entities don't inherit from FullAuditedEntity
        // so they don't have an IsDeleted property and can't use soft delete filters
        modelBuilder.Entity<Agent>(entity =>
        {
            // Reference data - no soft delete
        });

        modelBuilder.Entity<TypeAnesthesie>(entity =>
        {
            // Reference data - no soft delete
        });

        modelBuilder.Entity<Respirateur>(entity =>
        {
            // Reference data - no soft delete
        });

        modelBuilder.Entity<GradeScientifique>(entity =>
        {
            // Reference data - no soft delete
        });

        modelBuilder.Entity<Specialite>(entity =>
        {
            // Reference data - no soft delete
        });

        modelBuilder.Entity<Arme>(entity =>
        {
            // Reference data - no soft delete
        });

        modelBuilder.Entity<ExternalEntity>(entity =>
        {
            // Reference data - no soft delete
        });

        base.OnModelCreating(modelBuilder);
    }
}
