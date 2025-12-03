using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public partial class ProblemePreOperatoire : FullAuditedEntity
    {
        public ProblemePreOperatoire() { }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid InterventionId { get; set; }
    }
}
