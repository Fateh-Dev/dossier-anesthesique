using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class ConsigneAnesthesique : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public ConsigneAnesthesique() { }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public Guid ConsultationId { get; set; }
    }

    public class ConsigneAnesthesiqueReturnDto
    {
        public string Description { get; set; }
        // public Guid ConsultationId { get; set; }
    }
}
