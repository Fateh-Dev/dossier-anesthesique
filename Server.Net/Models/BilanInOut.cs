using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public partial class BilanInOut : FullAuditedEntity
    {
        public BilanInOut() { }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid InterventionId { get; set; }
    }
}
