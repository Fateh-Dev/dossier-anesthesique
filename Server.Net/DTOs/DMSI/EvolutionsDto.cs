using System;

namespace Server.Net.DTOs.DMSI
{
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
