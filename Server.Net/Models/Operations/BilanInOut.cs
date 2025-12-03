using System;

namespace Server.Net.Models.Operations
{
    public partial class BilanInOut : FullAuditedEntity
    {
        public BilanInOut() { }

        public string Description { get; set; }
        public Guid InterventionId { get; set; }
    }
}
