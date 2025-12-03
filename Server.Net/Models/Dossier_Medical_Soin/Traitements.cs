using System;

namespace Server.Net
{
    public class DMSI_Traitements_Encours
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DMSI_Dossiers_Medicaux? Dossier { get; set; }
        public Guid? DossierId { get; set; }
    }
}
