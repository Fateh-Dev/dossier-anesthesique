using System;

namespace Server.Net
{
    public class DMSI_Evolutions : FullAuditedEntity
    {
        public Guid DMSI_Dossiers_MedicauxId { get; set; }
        public DateTime Date { get; set; }
        public Guid? Medecin_1Id { get; set; }
        public Guid? Medecin_2Id { get; set; }
        public string Avis { get; set; }
        public DMSI_Dossiers_Medicaux? Dossier { get; set; }
        public Medecin? Medecin_1 { get; set; }
        public Medecin? Medecin_2 { get; set; }
    }

    public class DMSI_EvolutionsCreateOrUpdateDto
    {
        public Guid Id { get; set; }
        public Guid DMSI_Dossiers_MedicauxId { get; set; }
        public DateTime Date { get; set; }
        public Guid? Medecin_1Id { get; set; }
        public Guid? Medecin_2Id { get; set; }
        public string Avis { get; set; }
    }
}
