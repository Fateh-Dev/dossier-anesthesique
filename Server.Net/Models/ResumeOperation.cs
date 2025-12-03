using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class ResumeOperation : FullAuditedEntity
    {
        public ResumeOperation() { }

        public Guid Id { get; set; }
        public Guid InterventionId { get; set; }
        public string Induction { get; set; }
        public string Intubation { get; set; }
        public string Ventilation { get; set; }
        public string Entretien { get; set; }
        public string Reveil { get; set; }
        public string Extubation { get; set; }
    }

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
