using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Net.Models.Anesthesia
{
    public class ActeurIntervenant : FullAuditedEntity
    {
        public ActeurIntervenant() { }

        [Required]
        public Guid MedecinId { get; set; }

        [Required]
        public Guid InterventionId { get; set; }
    }
}
