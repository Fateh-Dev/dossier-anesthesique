using System;

namespace Server.Net.DTOs.Core
{
    public class MedecinReturnDto
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        //---------------------------New Attributs
        public string Nationnalite { get; set; }
        public string Sexe { get; set; }
        public string Matricule { get; set; } // Rempli Obligatoirement
        public DateTime? DateNaissance { get; set; }
        public string Specialite { get; set; }
        public string GradeScientifique { get; set; }
        public string Observation { get; set; }
        public string MetaData { get; set; } // Phrase comporte comme un log de tt les enregistrement
        public byte[] Image { get; set; } // Photo de profile
        public byte[] Thumbnail { get; set; } // Photo de Profile compressée
    }

    public class MedecinQuery
    {
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public string Sorting { get; set; }
        public string Nationnalite { get; set; }
        public Guid? Id { get; set; }
        public string Nom { get; set; }
        public string Specialite { get; set; }
        public string GradeScientifique { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string Matricule { get; set; } // Rempli Obligatoirement
        public DateTime? DateNaissance { get; set; }
    }

    public class MedecinToExcel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Matricule { get; set; }
        public string Nationnalite { get; set; }
        public string Specialite { get; set; }
        public string GradeScientifique { get; set; }
        public string Sexe { get; set; }
    }
}
