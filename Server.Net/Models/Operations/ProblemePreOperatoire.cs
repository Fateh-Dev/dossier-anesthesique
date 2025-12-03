using System;

namespace Server.Net.Models.Operations
{
    public partial class ProblemePreOperatoire : FullAuditedEntity
    {
        public ProblemePreOperatoire() { }

        public string Description { get; set; }
        public Guid InterventionId { get; set; }
    }
}
