namespace Server.Net.Models.Enumerations
{
    public enum Intubations
    {
        NonDefini,
        Orale,
        Nasale,
        Armee,
        Carlens,
        Autres,
    }

    public enum StatusIntervention
    {
        Consultation_Created, // Creer Consultation
        Examins_Cliniques,
        Consignes_Anesthesiques,
        Donnees_PreOperation,
        Bilan_Entrees_Sorties,
        Probleme_PerOperatoires,
        Deroulement_Operation,
        Resume_Anesthesique,
        Perscriptions_PostOperatoires,
    }
}
