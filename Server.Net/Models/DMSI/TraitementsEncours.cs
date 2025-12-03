using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Net.Models.DMSI
{
    public class DMSI_Traitements_Encours
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public DMSI_Dossiers_Medicaux? Dossier { get; set; }

        [Required]
        public Guid? DossierId { get; set; }
    }
}
