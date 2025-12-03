using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Net.Models.Anesthesia;
using Server.Net.Models.Enumerations;
using Server.Net.Models.Operations;

namespace Server.Net.Models.Entities
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
}
