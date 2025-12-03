using System;

namespace Server.Net.Models.DMSI
{
    public class DMSI_Metrics_Admission
    {
        public Guid Id { get; set; }
        public string Poids { get; set; }
        public string Taille { get; set; }
        public string BMI { get; set; }
        public string Temperature { get; set; }
        public string FreqRes { get; set; }
        public string SpO2_SansO2 { get; set; }
        public string SpO2SousO2 { get; set; } // L
        public string ScoreGlasgow { get; set; } // /15
        public string OY { get; set; }
        public string RV { get; set; }
        public string RM { get; set; }
        public string Pupilles { get; set; }
        public string DeficitMoteur { get; set; }
        public string PA { get; set; } // mmHg
        public string Pouls { get; set; } // Bpm
        public string Diurese { get; set; } // cc/h
        public string Etat { get; set; }
        public DMSI_Dossiers_Medicaux? Dossier { get; set; }
        public Guid? DossierId { get; set; }
    }
}
