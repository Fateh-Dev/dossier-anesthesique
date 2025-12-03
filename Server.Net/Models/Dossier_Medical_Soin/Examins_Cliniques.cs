using System;

namespace Server.Net
{
    public class DMSI_Examins_Cliniques
    {
        public Guid Id { get; set; }
        public string Ex_General { get; set; }
        public string Ex_Neurologique { get; set; }
        public string Ex_Cardiovasculaire { get; set; }
        public string Pleuro_Pulmonaire { get; set; }
        public string Ex_Uro_Nephrologie { get; set; }
        public string Ex_Gastro_intestinal { get; set; }
        public string Evaluation_EVA { get; set; }
        public string Evaluation_EOC { get; set; }
        public string Evaluation_DN4 { get; set; }
        public string Autres { get; set; }
        public DMSI_Dossiers_Medicaux? Dossier { get; set; }
        public Guid? DossierId { get; set; }
    }

    public class DMSI_Examins_CliniquesCreateOrUpdateDo
    {
        public Guid Id { get; set; }
        public string Ex_General { get; set; }
        public string Ex_Neurologique { get; set; }
        public string Ex_Cardiovasculaire { get; set; }
        public string Pleuro_Pulmonaire { get; set; }
        public string Ex_Uro_Nephrologie { get; set; }
        public string Ex_Gastro_intestinal { get; set; }
        public string Evaluation_EVA { get; set; }
        public string Evaluation_EOC { get; set; }
        public string Evaluation_DN4 { get; set; }
        public string Autres { get; set; }
        public Guid? DossierId { get; set; }
    }
}
