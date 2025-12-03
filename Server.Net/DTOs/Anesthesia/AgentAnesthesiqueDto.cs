using System;

namespace Server.Net.DTOs.Anesthesia
{
    public partial class AgentAnesthesiqueCreateDto
    {
        public string? Agent { get; set; }
        public string? Dose { get; set; }
        public string? temps { get; set; }
        public Guid InterventionId { get; set; }
    }
}
