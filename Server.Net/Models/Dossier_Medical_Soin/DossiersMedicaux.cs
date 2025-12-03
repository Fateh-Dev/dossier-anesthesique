using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class DMSI_Dossiers_Medicaux : FullAuditedEntity
    {
        [Required]
        public Guid PatientId { get; set; } // Required

        [Required]
        public Guid MedecinId { get; set; } // Required

        [Range(0, 150)]
        public int? Age { get; set; } // Performance Purpose

        [MaxLength(500)]
        public string Provenance { get; set; }

        [MaxLength(2000)]
        public string MotifAdmission { get; set; }

        [Required]
        public DateTime DateAdmission { get; set; }

        public DateTime? DateSortie { get; set; }

        [MaxLength(200)]
        public string ModeSortie { get; set; }

        [MaxLength(200)]
        public string CaractereUrgent { get; set; }

        [MaxLength(20)]
        public string PersonneAJoindreTel { get; set; }

        public bool AvoirCovid { get; set; }

        [MaxLength(200)]
        public string VaccinationCovid { get; set; }

        public string HistoireDuMalade { get; set; }
        public DMSI_Metrics_Admission? A_Admission { get; set; }
        public DMSI_Examins_Complementaires? Examins_Complementaires { get; set; }
        public ICollection<DMSI_Antecedents>? Antecedents { get; set; }
        public ICollection<DMSI_Traitements_Encours>? Traitements { get; set; }
        public ICollection<DMSI_Evolutions>? Evolutions { get; set; }
        public DMSI_Examins_Cliniques? Examins_Cliniques { get; set; }
        public DMSI_Conduite? DMSI_Conduite { get; set; }
        public Medecin? Medecin { get; set; }
        public Patient? Patients { get; set; }
    }

    public class DMSI_Dossiers_MedicauxDto
    {
        public Guid PatientId { get; set; } // Required
        public Guid MedecinId { get; set; } // Required
        public int? Age { get; set; } // Performance Purpose
        public string Provenance { get; set; }
        public string MotifAdmission { get; set; }
        public DateTime DateAdmission { get; set; }
        public DateTime? DateSortie { get; set; }
        public string ModeSortie { get; set; }
        public string CaractereUrgent { get; set; }
        public string PersonneAJoindreTel { get; set; }
    }
}
