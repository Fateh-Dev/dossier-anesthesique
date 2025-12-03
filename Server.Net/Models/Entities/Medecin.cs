using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Net.Models.Enumerations;

namespace Server.Net.Models.Entities
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

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }

        [Required]
        [MaxLength(100)]
        public string Prenom { get; set; }

        //---------------------------New Attributs
        [MaxLength(100)]
        public string Nationnalite { get; set; }

        [MaxLength(20)]
        public string Sexe { get; set; }

        [MaxLength(200)]
        public string Specialite { get; set; }

        [MaxLength(20)]
        public string NumeroTel { get; set; }

        [MaxLength(20)]
        public string NumeroTel2 { get; set; }

        [MaxLength(100)]
        public string GradeActuel { get; set; }

        [MaxLength(200)]
        public string GradeScientifique { get; set; }

        [MaxLength(20)]
        public string Matricule { get; set; } // Rempli Obligatoirement

        public DateTime? DateNaissance { get; set; }

        [MaxLength(1000)]
        public string Observation { get; set; }

        public string MetaData { get; set; } // Phrase comporte comme un log de tt les enregistrement
        public byte[] Image { get; set; } // Photo de profile
        public byte[] Thumbnail { get; set; } // Photo de Profile compressée

        public virtual ICollection<Consultation> Consultations { get; set; }
    }
}
