using System;

namespace Server.Net
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

    public class DMSI_Examins_Complementaires
    {
        public Guid Id { get; set; }
        public DMSI_Dossiers_Medicaux? Dossier { get; set; }
        public Guid? DossierId { get; set; }
        public string HB { get; set; }
        public string GR { get; set; }
        public string PLQ { get; set; }
        public string GB { get; set; }
        public string HT { get; set; }
        public string GLY { get; set; }
        public string HBA { get; set; } // L
        public string Uree { get; set; } // /15
        public string Creatinine { get; set; }
        public string Clairance { get; set; }
        public string Na { get; set; }
        public string K { get; set; }
        public string Ca { get; set; }
        public string Mg { get; set; } // mmHg
        public string TG { get; set; } // Bpm
        public string CHOL_TTL { get; set; } // cc/h
        public string LDL { get; set; }
        public string HDL { get; set; }
        public string ALAT { get; set; }
        public string ASAT { get; set; }
        public string GGT { get; set; }
        public string PAL { get; set; }
        public string T_Protides { get; set; }
        public string Electrophorese_Proteines { get; set; }
        public string Albumine { get; set; }
        public string TP { get; set; }
        public string TCK { get; set; }
        public string INR { get; set; }
        public string Sintrom_Dose { get; set; }
        public string CRP { get; set; }
        public string VS { get; set; }
        public string Fibrinogene { get; set; }
        public string Ferritinemie { get; set; }
        public string Troponine_T { get; set; }
        public string NT_Pro_BNP { get; set; }
        public string D_Dimeres { get; set; }
        public string CPK_MB { get; set; }
        public string PH { get; set; }
        public string PaCO2 { get; set; }
        public string PaO2 { get; set; }
        public string HCO3 { get; set; }
        public string FIO2 { get; set; }
        public string LACTATES { get; set; }
        public string PaO2_FiO2 { get; set; }
        public string Commentaire { get; set; }
        public string Radiographie_Thorax { get; set; }
        public string ECG { get; set; }
        public string Echographie_Cardiaque { get; set; }
    }
}
