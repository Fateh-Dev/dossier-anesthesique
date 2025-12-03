using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Net.Models.Anesthesia;
using Server.Net.Models.Enumerations;

namespace Server.Net.Models.Entities
{
    public class Consultation : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public Consultation() { }

        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(2000)]
        public string DescriptionConsultation { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public DateTime DateConsultation { get; set; }

        public DateTime DateInterventionPrevu { get; set; }
        public Guid? MedecinId { get; set; }
        public virtual Medecin Medecin { get; set; }
        public virtual Patient Patient { get; set; }

        // public virtual Patient Paatient { get; set; }
        public bool Urgence { get; set; }

        [Range(0, 500)]
        public double? Poids { get; set; }

        [Range(0, 100)]
        public double? BMI { get; set; }

        [Range(0, 300)]
        public double? Taille { get; set; }

        [Range(0, 10)]
        public double? S_c { get; set; }

        [MaxLength(2000)]
        public string TraitementActuel { get; set; }

        [MaxLength(2000)]
        public string TraitementAPoursuivre { get; set; }

        [MaxLength(2000)]
        public string ConclusionExamin { get; set; }

        [MaxLength(500)]
        public string PrevisionCG { get; set; }

        [MaxLength(500)]
        public string PrevisionPF { get; set; }

        [MaxLength(500)]
        public string PrevisionPlaquette { get; set; }

        [MaxLength(100)]
        public string TypeAnesthesie { get; set; }

        [MaxLength(50)]
        public string Asa { get; set; }
        public StatusConsultation status { get; set; }
        public virtual ICollection<ConsigneAnesthesique> ConsignesAnesthesiques { get; set; }
        public virtual ICollection<ExaminClinique> ExaminsCliniques { get; set; }
    }
}
