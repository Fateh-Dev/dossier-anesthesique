using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Server.Net.Models.Antecedents;

namespace Server.Net.Models.Entities
{
    public class Patient : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public Patient()
        {
            // Nomination = new HashSet<Nomination>();
        }

        public void SetSituationFamilliale(SituationFamilliale input)
        {
            this.SituationFamilliale = input;
            if (input == SituationFamilliale.Célibataire)
                this.NombreEnfant = 0;
        }

        //TODO Get Lieu Naissance From Matricule
        public void fixLieuNaissanceFromMatricule()
        {
            Wilayas wilaya = (Wilayas)Int32.Parse(this.Matricule.Substring(5, 2)) - 1;
            this.LieuNaissance = wilaya.ToString();
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

        public SituationFamilliale SituationFamilliale { get; set; } =
            SituationFamilliale.Célibataire;

        [Range(0, 50)]
        public int? NombreEnfant { get; set; } = 0;

        //-------------------------------------------
        [MaxLength(100)]
        public string NomAr { get; set; }

        [MaxLength(100)]
        public string PrenomAr { get; set; }

        [MaxLength(500)]
        public string AdresseAr { get; set; }

        [MaxLength(100)]
        public string PrenomPereAr { get; set; }

        [MaxLength(100)]
        public string NomMereAr { get; set; }

        [MaxLength(20)]
        public string NumeroTel { get; set; }

        [MaxLength(20)]
        public string NumeroTel2 { get; set; }

        [MaxLength(100)]
        public string GradeActuel { get; set; }

        [Range(0, 300)]
        public double? Taille { get; set; } = 0;

        [Range(0, 500)]
        public double? Poids { get; set; } = 0;

        [Required]
        [MaxLength(20)]
        public string Sexe { get; set; }

        [Required]
        [MaxLength(20)]
        public string Matricule { get; set; } // Rempli Obligatoirement

        public DateTime? DateNaissance { get; set; }

        [MaxLength(200)]
        public string LieuNaissance { get; set; }

        [MaxLength(10)]
        public string Groupage { get; set; }

        [MaxLength(500)]
        public string Adresse { get; set; }

        [MaxLength(100)]
        public string PrenomPere { get; set; }

        [MaxLength(100)]
        public string NomMere { get; set; } // Nom et Prenom

        [MaxLength(1000)]
        public string Observation { get; set; }

        public string MetaData { get; set; } // Phrase comporte comme un log de tt les enregistrement
        public byte[] Image { get; set; } // Photo de profile
        public byte[] Thumbnail { get; set; } // Photo de Profile compressée

        public virtual ICollection<AntecedentChirurgical> AntecedentsChirurgicaux { get; set; }
        public virtual ICollection<AntecedentMedical> AntecedentsMedicaux { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }
}
