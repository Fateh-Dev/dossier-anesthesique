using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class Intervention : FullAuditedEntity
    {
        public Intervention() { }

        public Guid Id { get; set; }

        [Range(0, 2000)]
        public double DureeIntervention { get; set; }

        [Range(0, 2000)]
        public double DureeAnesthesie { get; set; }

        [Required]
        public Guid ConsultationId { get; set; }

        public bool Urgence { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public virtual Consultation Consultation { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [MaxLength(500)]
        public string MonitorageVoieArt { get; set; }

        [MaxLength(1000)]
        public string MonitorageAutres { get; set; }

        [MaxLength(100)]
        public string TypeAnesthesie { get; set; }

        [MaxLength(50)]
        public string Asa { get; set; }
        public bool SVesicale { get; set; } = false;
        public bool STemp { get; set; } = false;
        public bool MatChauf { get; set; } = false;
        public bool SGast { get; set; } = false;

        [MaxLength(200)]
        public string Position { get; set; }

        public Intubations Intubation { get; set; }
        public StatusIntervention Status { get; set; }

        [MaxLength(500)]
        public string AutreIntubation { get; set; }

        [MaxLength(200)]
        public string Circuit { get; set; }

        [MaxLength(200)]
        public string Respirateur { get; set; }

        public virtual ICollection<BilanInOut> BilanInOut { get; set; }
        public virtual ICollection<ProblemePreOperatoire> ProblemesPreOperatoires { get; set; }
        public virtual ICollection<AgentAnesthesique> AgentsAnesthsesiques { get; set; }
        public virtual ICollection<ActeurIntervenant> ActeursIntervenants { get; set; }
        public virtual ICollection<PostOperation> PostOperation { get; set; }
        public virtual ICollection<DeroulementOperatoire> OperationDetails { get; set; }
        public virtual ICollection<ResumeOperation> ResumeOperation { get; set; }
    }

    public enum Intubations
    {
        NonDefini,
        Orale,
        Nasale,
        Armee,
        Carlens,
        Autres,
    }

    public enum StatusIntervention
    {
        Consultation_Created, // Creer Consultation
        Examins_Cliniques,
        Consignes_Anesthesiques,
        Donnees_PreOperation,
        Bilan_Entrees_Sorties,
        Probleme_PerOperatoires,
        Deroulement_Operation,
        Resume_Anesthesique,
        Perscriptions_PostOperatoires,
    }

    public class InterventionHomeRetuenDto
    {
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public DateTime? Date { get; set; }
    }

    public class InterventionEntryDto
    {
        public ICollection<ActeurIntervenant> fixActors()
        {
            ICollection<ActeurIntervenant> Acteurs = null;
            foreach (var item in MedecinsIntervenants)
            {
                Acteurs.Add(
                    new ActeurIntervenant() { MedecinId = Guid.Parse(item), InterventionId = Id }
                );
            }
            return Acteurs;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string MonitorageVoieArt { get; set; }
        public string MonitorageAutres { get; set; }
        public string StartTime { get; set; }

        public bool? SVesicale { get; set; } = false;
        public bool? STemp { get; set; } = false;
        public bool? MatChauf { get; set; } = false;
        public bool? SGast { get; set; } = false;
        public string Position { get; set; }
        public Intubations? Intubation { get; set; } = Intubations.NonDefini;
        public string AutreIntubation { get; set; }

        public string Circuit { get; set; }
        public string Respirateur { get; set; }

        public virtual ICollection<BilanInOut>? BilanInOut { get; set; }
        public virtual ICollection<ProblemePreOperatoire>? ProblemesPreOperatoires { get; set; }
        public virtual ICollection<string>? MedecinsIntervenants { get; set; }
    }

    public class InterventionQuery
    {
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public string Sorting { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string TypeAnesthesie { get; set; }
        public string Asa { get; set; }
        public string Nom { get; set; }
        public string Diagnostique { get; set; }
        public string NomMedecin { get; set; }
        public string Sexe { get; set; }
        public string Groupage { get; set; }
        public string Matricule { get; set; }

        public int? Year { get; set; }
        public int? Mois { get; set; }
        public StatusIntervention? Status { get; set; }
        public bool? Urgence { get; set; }
    }

    public class InterventionToExcel
    {
        public string Date { get; set; }
        public string Patient { get; set; }
        public string Groupage { get; set; }
        public string Matricule { get; set; }
        public string Diagnostique { get; set; }
        public string Medecin { get; set; }
        public string Sexe { get; set; }
        public string TypeAnesthesie { get; set; }
        public string Asa { get; set; }
    }
}
