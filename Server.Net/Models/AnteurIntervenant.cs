using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class ActeurIntervenant : FullAuditedEntity
    {
        public ActeurIntervenant() { }

        public Guid Id { get; set; }
        public Guid MedecinId { get; set; }
        public Guid InterventionId { get; set; }
    }
}
