using System;

namespace Server.Net.DTOs.DMSI
{
    public class DMSI_ConduiteCreateOrUpdateDto
    {
        public Guid Id { get; set; }
        public Guid IdDossier { get; set; }

        // Plan Respiratoire
        public string ModeVentilatoire { get; set; }
        public string SiVsDebitO2 { get; set; }
        public string SiCpapDebitO2 { get; set; }
        public string SiBipapFiO2 { get; set; }
        public string SiBipapPep { get; set; }
        public string SiBipapAi { get; set; }
        public string SiBipapTrigger { get; set; }
        public string SiBipapPente { get; set; }
        public string SiBipapTriggerExp { get; set; }
        public string SiBipapTiMax { get; set; }
        public string SiVaciFr { get; set; }
        public string SiVaciVt { get; set; }
        public string SiVaciIe { get; set; }
        public string SiVaciFio2 { get; set; }
        public string SiVaciPep { get; set; }
        public string DebitInsp { get; set; }
        public string PlanRespAutre { get; set; }
        public string PauseTeleinsp { get; set; }

        // Plan Cardiovasculaire
        public string Pa { get; set; }
        public string Fc { get; set; }
        public string Ic { get; set; }
        public string Ves { get; set; }
        public string Rvs { get; set; }
        public string Nad { get; set; }
        public string Ad { get; set; }
        public string Dobutamine { get; set; }
        public string PlanCardioAutre { get; set; }
        public string Echocardio { get; set; }

        // Plan Rénal
        public string Diurese { get; set; }
        public string ClearanceCreat { get; set; }
        public string Remplissage { get; set; }
        public string OptimisationHd { get; set; }
        public string Diuretique { get; set; }
        public string DialCritere { get; set; }
        public string HeuresDialyse { get; set; }

        // Autre Traitements
        public string Atb { get; set; }
        public string Atc { get; set; }
        public string Sedation { get; set; }
        public string Nutrition { get; set; }
        public string AutreTrait { get; set; }
    }
}
