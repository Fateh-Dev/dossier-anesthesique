using System;
using System.Collections.Generic;

namespace Server.Net
{
    public partial class ExternalPersonne
    {
        public string Matricule { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        //***************************************************************************
        public DateTime? DateNaissance { get; set; }

        public string Grade { get; set; }
        public Guid? IdUnite { get; set; }
        public Guid? IdEscadre { get; set; }
        public Guid? IdEscadron { get; set; }
        public string LibFilePhoto { get; set; }
        public string LibExtensionPhoto { get; set; }
        public Decision? Expertise { get; set; }
        public List<Attestation> Attestations { get; set; }
    }

    public class Attestation
    {
        public string Diplome { get; set; }
        public DateTime? Date { get; set; }
        public List<string> Etablis { get; set; }
        public List<string> TypeAeros { get; set; }
    }
}
