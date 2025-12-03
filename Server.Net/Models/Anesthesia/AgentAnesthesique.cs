using System;

namespace Server.Net.Models.Anesthesia
{
    // Agents that are related to intervention
    public partial class AgentAnesthesique
    {
        public AgentAnesthesique() { }

        // public AgentAnesthesique(string temps, string agent, string dose, Guid IdIntervention)
        // {
        // }
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public string? Agent { get; set; }
        public string? Dose { get; set; }
        public string? temps { get; set; }
        public Guid InterventionId { get; set; }
    }
}
