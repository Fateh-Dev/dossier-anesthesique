using System;
using System.ComponentModel.DataAnnotations;
using Server.Net.Models.Enumerations;

namespace Server.Net.Models.Antecedents
{
    public class AntecedentMedical : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public AntecedentMedical() { }

        public TypeAntecedent TypeAntecedent { get; set; }
        public string Description { get; set; }
        public string TypeAntecedentLabel { get; set; }
        public Guid PatientId { get; set; }
    }
}
