using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Net.Models.Anesthesia
{
    public class ExaminClinique : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public ExaminClinique() { }

        public string Description { get; set; }
        public int TypeExamin { get; set; }
        public string TypeExaminLabel { get; set; }
        public Guid ConsultationId { get; set; }
    }
}
