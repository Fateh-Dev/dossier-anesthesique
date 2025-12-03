using System;
using System.Collections.Generic;

namespace Server.Net
{
    public partial class ExternalAptitudeMedicale
    {
        public Decision? CodeDecision { get; set; }
        public DateTime DatApt { get; set; }
        public int? DureeApt { get; set; } // in days
        public List<int?> CodeObservationExpertise { get; set; }
        public int? CodeTypeExpertise { get; set; }
        public int? CodeLieu { get; set; }
        public int? CodeAffection { get; set; }
        public int? CodeMedecin { get; set; }
        public int? CodeCategoriePn { get; set; }
        public DateTime DateTestProchaine { get; set; }
        public Guid IdPersonne { get; set; }
    }

    public enum Decision
    {
        //TO FIX LATER
        NoData = -1,
        Apte,
        Inapte_temporaire,
        Inapte_definitive,
        Apte_par_derogation,
    }
}
