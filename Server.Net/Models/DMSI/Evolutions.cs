using System;
using System.ComponentModel.DataAnnotations;
using Server.Net.Models.Entities;

namespace Server.Net.Models.DMSI
{
    public class DMSI_Evolutions : FullAuditedEntity
    {
        [Required]
        public Guid DMSI_Dossiers_MedicauxId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public Guid? Medecin_1Id { get; set; }
        public Guid? Medecin_2Id { get; set; }
        public string Avis { get; set; }
        public DMSI_Dossiers_Medicaux? Dossier { get; set; }
        public Medecin? Medecin_1 { get; set; }
        public Medecin? Medecin_2 { get; set; }
    }
}
