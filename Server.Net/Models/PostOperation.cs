using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public partial class PostOperation : FullAuditedEntity
    {
        public PostOperation() { }

        public Guid Id { get; set; }
        public Guid InterventionId { get; set; }
        public string ConsignsParticuliersReveil { get; set; }
        public string AnalogiqueReveil { get; set; }
        public string AutreReveil { get; set; }
        public string FlaconBloc { get; set; }
        public DateTime DatePrescription { get; set; }
        public string AntiCoagulants { get; set; }
        public string Antalogique { get; set; }
        public string Antibiotique { get; set; }
        public string Autres { get; set; }
        public string RealPostop { get; set; }
        public string Surveillance { get; set; }
        public string Bilan { get; set; }
        public string SortieAutorise { get; set; }
        public DateTime DateBilan { get; set; }
    }

    public class PostOperationCreateDto
    {
        public Guid InterventionId { get; set; }
        public string ConsignsParticuliersReveil { get; set; }
        public string AnalogiqueReveil { get; set; }
        public string AutreReveil { get; set; }
        public string FlaconBloc { get; set; }
        public DateTime? DatePrescription { get; set; }
        public string AntiCoagulants { get; set; }
        public string Antalogique { get; set; }
        public string Antibiotique { get; set; }
        public string Autres { get; set; }
        public string RealPostop { get; set; }
        public string Surveillance { get; set; }
        public string Bilan { get; set; }
        public string SortieAutorise { get; set; }
        public DateTime? DateBilan { get; set; }
    }
}
