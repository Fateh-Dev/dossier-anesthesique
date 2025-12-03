using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class ExaminClinique : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public ExaminClinique() { }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public int TypeExamin { get; set; }
        public string TypeExaminLabel { get; set; }
        public Guid ConsultationId { get; set; }
    }

    public class ExaminCliniqueReturnDto
    {
        public string Description { get; set; }

        // public int TypeExamin { get; set; }
        public string TypeExaminLabel { get; set; }
        // public Guid ConsultationId { get; set; }
    }
}
