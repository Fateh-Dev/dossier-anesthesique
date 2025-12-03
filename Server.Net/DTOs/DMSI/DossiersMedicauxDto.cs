using System;

namespace Server.Net.DTOs.DMSI
{
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
