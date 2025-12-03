using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class Medecin : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public Medecin()
        {
            // Nomination = new HashSet<Nomination>();
        }

        public void fixSexeFromMatricule()
        {
            Sexe sexe = (Sexe)Int32.Parse(this.Matricule.Substring(7, 1));
            this.Sexe = sexe.ToString();
        }

        public string Nom { get; set; }
        public string Prenom { get; set; }

        //---------------------------New Attributs
        public string Nationnalite { get; set; }
        public string Sexe { get; set; }
        public string Specialite { get; set; }
        public string NumeroTel { get; set; }
        public string NumeroTel2 { get; set; }
        public string GradeActuel { get; set; }
        public string GradeScientifique { get; set; }
        public string Matricule { get; set; } // Rempli Obligatoirement
        public DateTime? DateNaissance { get; set; }
        public string Observation { get; set; }
        public string MetaData { get; set; } // Phrase comporte comme un log de tt les enregistrement
        public byte[] Image { get; set; } // Photo de profile
        public byte[] Thumbnail { get; set; } // Photo de Profile compressée

        public virtual ICollection<Consultation> Consultations { get; set; }
    }

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

    public enum Specialites
    {
        undefined,
        Anesthesiste,
        Chirurgien,
    }

    public enum GradesScientifiques
    {
        undefined,
        Docteur,
        Professeur,
    }
}
