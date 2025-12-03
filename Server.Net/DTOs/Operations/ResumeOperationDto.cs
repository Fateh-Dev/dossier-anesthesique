using System;

namespace Server.Net.DTOs.Operations
{
    public class ResumeOperationCreateDto
    {
        public Guid InterventionId { get; set; }
        public string Induction { get; set; }
        public string Intubation { get; set; }
        public string Ventilation { get; set; }
        public string Entretien { get; set; }
        public string Reveil { get; set; }
        public string Extubation { get; set; }
    }
}
