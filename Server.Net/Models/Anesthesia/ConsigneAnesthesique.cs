using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Net.Models.Anesthesia
{
    public class ConsigneAnesthesique : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public ConsigneAnesthesique() { }

        public string Description { get; set; }
        public Guid ConsultationId { get; set; }
    }
}
