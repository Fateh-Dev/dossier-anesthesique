using System;
using System.Collections.Generic;
using Server.Net.Models.DMSI;

namespace Server.Net.DTOs.DMSI
{
    public class MedicalDossier
    {
        public Guid? Id { get; set; }
        public bool AvoirCovid { get; set; }
        public string VaccinationCovid { get; set; }
        public string HistoireDuMalade { get; set; }
        public List<DMSI_Antecedents> Antecedents { get; set; }
        public List<DMSI_Traitements_Encours> TraitementsEncours { get; set; }
    }
}
