using System;
using Server.Net.Models.Enumerations;

namespace Server.Net.DTOs.Antecedents
{
    public class AntecedentMedicalReturnDto
    {
        public Guid Id { get; set; }
        public TypeAntecedent TypeAntecedent { get; set; }
        public string Description { get; set; }
        public string TypeAntecedentLabel { get; set; }
        public Guid PatientId { get; set; }
    }
}
