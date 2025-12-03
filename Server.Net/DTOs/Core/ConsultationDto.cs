using System;
using System.Collections.Generic;
using Server.Net.DTOs.Anesthesia;
using Server.Net.Models.Enumerations;

namespace Server.Net.DTOs.Core
{
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
        public double? Poids { get; set; }
        public double? BMI { get; set; }
        public double? Taille { get; set; }
        public double? S_c { get; set; }
        public virtual ICollection<ConsigneAnesthesiqueReturnDto> ConsignesAnesthesiques { get; set; }
        public virtual ICollection<ExaminCliniqueReturnDto> ExaminsCliniques { get; set; }
    }
}
