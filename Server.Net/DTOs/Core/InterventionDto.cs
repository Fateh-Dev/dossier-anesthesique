using System;
using System.Collections.Generic;
using Server.Net.Models.Anesthesia;
using Server.Net.Models.Enumerations;
using Server.Net.Models.Operations;

namespace Server.Net.DTOs.Core
{
    public class InterventionHomeRetuenDto
    {
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public DateTime? Date { get; set; }
    }

    public class InterventionEntryDto
    {
        public ICollection<ActeurIntervenant> fixActors()
        {
            ICollection<ActeurIntervenant> Acteurs = new List<ActeurIntervenant>();
            if (MedecinsIntervenants != null)
            {
                foreach (var item in MedecinsIntervenants)
                {
                    Acteurs.Add(
                        new ActeurIntervenant()
                        {
                            MedecinId = Guid.Parse(item),
                            InterventionId = Id,
                        }
                    );
                }
            }
            return Acteurs;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public string MonitorageVoieArt { get; set; }
        public string MonitorageAutres { get; set; }
        public string StartTime { get; set; }

        public bool? SVesicale { get; set; } = false;
        public bool? STemp { get; set; } = false;
        public bool? MatChauf { get; set; } = false;
        public bool? SGast { get; set; } = false;
        public string Position { get; set; }
        public Intubations? Intubation { get; set; } = Intubations.NonDefini;
        public string AutreIntubation { get; set; }

        public string Circuit { get; set; }
        public string Respirateur { get; set; }

        public virtual ICollection<BilanInOut>? BilanInOut { get; set; }
        public virtual ICollection<ProblemePreOperatoire>? ProblemesPreOperatoires { get; set; }
        public virtual ICollection<string>? MedecinsIntervenants { get; set; }
    }

    public class InterventionQuery
    {
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public string Sorting { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
        public string TypeAnesthesie { get; set; }
        public string Asa { get; set; }
        public string Nom { get; set; }
        public string Diagnostique { get; set; }
        public string NomMedecin { get; set; }
        public string Sexe { get; set; }
        public string Groupage { get; set; }
        public string Matricule { get; set; }

        public int? Year { get; set; }
        public int? Mois { get; set; }
        public StatusIntervention? Status { get; set; }
        public bool? Urgence { get; set; }
    }

    public class InterventionToExcel
    {
        public string Date { get; set; }
        public string Patient { get; set; }
        public string Groupage { get; set; }
        public string Matricule { get; set; }
        public string Diagnostique { get; set; }
        public string Medecin { get; set; }
        public string Sexe { get; set; }
        public string TypeAnesthesie { get; set; }
        public string Asa { get; set; }
    }
}
