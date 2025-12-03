using System;

namespace Server.Net
{
    public class DMSI_Antecedents : FullAuditedEntity
    {
        public Guid DMSI_Dossiers_MedicauxId { get; set; }
        public string Description { get; set; }
        public DMSI_Dossiers_Medicaux? Dossier { get; set; }
    }
}
