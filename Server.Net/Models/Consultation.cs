using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class Consultation : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public Consultation() { }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string DescriptionConsultation { get; set; }
        public Guid PatientId { get; set; }
        public DateTime DateConsultation { get; set; }
        public DateTime DateInterventionPrevu { get; set; }
        public Guid? MedecinId { get; set; }
        public virtual Medecin Medecin { get; set; }
        public virtual Patient Patient { get; set; }

        // public virtual Patient Paatient { get; set; }
        public bool Urgence { get; set; }
        public string Poids { get; set; }
        public string BMI { get; set; }
        public string Taille { get; set; }
        public string S_c { get; set; }
        public string TraitementActuel { get; set; }
        public string TraitementAPoursuivre { get; set; }
        public string ConclusionExamin { get; set; }
        public string PrevisionCG { get; set; }
        public string PrevisionPF { get; set; }
        public string PrevisionPlaquette { get; set; }
        public string TypeAnesthesie { get; set; }
        public string Asa { get; set; }
        public StatusConsultation status { get; set; }
        public virtual ICollection<ConsigneAnesthesique> ConsignesAnesthesiques { get; set; }
        public virtual ICollection<ExaminClinique> ExaminsCliniques { get; set; }
    }

    public class ConsultationReturnDto
    {
        public Guid Id { get; set; }
        public string DescriptionConsultation { get; set; }
        public Guid PatientId { get; set; }
        public DateTime DateConsultation { get; set; }
        public StatusConsultation status { get; set; }
        public DateTime DateInterventionPrevu { get; set; }
        public Guid? MedecinId { get; set; }
        public virtual MedecinReturnDto Medecin { get; set; }
        public bool Urgence { get; set; }
        public string Poids { get; set; }
        public string BMI { get; set; }
        public string Taille { get; set; }
        public string S_c { get; set; }
        public virtual ICollection<ConsigneAnesthesiqueReturnDto> ConsignesAnesthesiques { get; set; }
        public virtual ICollection<ExaminCliniqueReturnDto> ExaminsCliniques { get; set; }
    }

    public enum StatusConsultation
    {
        Pending,
        Closed,
    }
}
