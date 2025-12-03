using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class AntecedentChirurgical : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public AntecedentChirurgical() { }

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public Guid PatientId { get; set; }
    }

    public class AntecedentChirurgicalReturnDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid PatientId { get; set; }
    }
}
