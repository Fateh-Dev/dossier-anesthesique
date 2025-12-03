using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Net.Models.Antecedents
{
    public class AntecedentChirurgical : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public AntecedentChirurgical() { }

        public string Description { get; set; }
        public Guid PatientId { get; set; }
    }
}
