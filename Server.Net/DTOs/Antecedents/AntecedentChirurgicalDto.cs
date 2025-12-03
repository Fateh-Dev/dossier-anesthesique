using System;

namespace Server.Net.DTOs.Antecedents
{
    public class AntecedentChirurgicalReturnDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid PatientId { get; set; }
    }
}
