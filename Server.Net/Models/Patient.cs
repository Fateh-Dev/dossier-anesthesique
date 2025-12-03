using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class PatientReturnDto
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        //---------------------------New Attributs
        public string Nationnalite { get; set; }
        public SituationFamilliale SituationFamilliale { get; set; } =
            SituationFamilliale.Célibataire;
        public int? NombreEnfant { get; set; } = 0;

        //-------------------------------------------
        public string NomAr { get; set; }
        public string PrenomAr { get; set; }
        public string AdresseAr { get; set; }
        public string PrenomPereAr { get; set; }
        public string NomMereAr { get; set; }
        public string NumeroTel { get; set; }
        public string NumeroTel2 { get; set; }
        public string GradeActuel { get; set; }
        public double? Taille { get; set; } = 0;
        public double? Poids { get; set; } = 0;
        public string Sexe { get; set; }
        public string Matricule { get; set; } // Rempli Obligatoirement
        public DateTime? DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public string Groupage { get; set; }
        public string Adresse { get; set; }
        public string PrenomPere { get; set; }
        public string NomMere { get; set; } // Nom et Prenom
        public string Observation { get; set; }
        public string MetaData { get; set; } // Phrase comporte comme un log de tt les enregistrement
        public byte[] Image { get; set; } // Photo de profile
        public byte[] Thumbnail { get; set; } // Photo de Profile compressée

        public virtual ICollection<AntecedentChirurgicalReturnDto> AntecedentsChirurgicaux { get; set; }
        public virtual ICollection<AntecedentMedicalReturnDto> AntecedentsMedicaux { get; set; }
        public virtual ICollection<ConsultationReturnDto> Consultations { get; set; }
        public virtual ICollection<Intervention> Interventions { get; set; }
    }

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

        public string Nom { get; set; }
        public string Prenom { get; set; }

        //---------------------------New Attributs
        public string Nationnalite { get; set; }
        public SituationFamilliale SituationFamilliale { get; set; } =
            SituationFamilliale.Célibataire;
        public int? NombreEnfant { get; set; } = 0;

        //-------------------------------------------
        public string NomAr { get; set; }
        public string PrenomAr { get; set; }
        public string AdresseAr { get; set; }
        public string PrenomPereAr { get; set; }
        public string NomMereAr { get; set; }
        public string NumeroTel { get; set; }
        public string NumeroTel2 { get; set; }
        public string GradeActuel { get; set; }
        public double? Taille { get; set; } = 0;
        public double? Poids { get; set; } = 0;
        public string Sexe { get; set; }
        public string Matricule { get; set; } // Rempli Obligatoirement
        public DateTime? DateNaissance { get; set; }
        public string LieuNaissance { get; set; }
        public string Groupage { get; set; }
        public string Adresse { get; set; }
        public string PrenomPere { get; set; }
        public string NomMere { get; set; } // Nom et Prenom
        public string Observation { get; set; }
        public string MetaData { get; set; } // Phrase comporte comme un log de tt les enregistrement
        public byte[] Image { get; set; } // Photo de profile
        public byte[] Thumbnail { get; set; } // Photo de Profile compressée

        public virtual ICollection<AntecedentChirurgical> AntecedentsChirurgicaux { get; set; }
        public virtual ICollection<AntecedentMedical> AntecedentsMedicaux { get; set; }
        public virtual ICollection<Consultation> Consultations { get; set; }
        // public virtual ICollection<Intervention> Interventions { get; set; }
    }

    public class PatientQuery
    {
        public int MaxResultCount { get; set; }
        public int SkipCount { get; set; }
        public string Sorting { get; set; }
        public Guid? Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

        //---------------------------New Attributs
        public string Nationnalite { get; set; }
        public string Groupage { get; set; }
        public SituationFamilliale SituationFamilliale { get; set; }
        public double? Taille { get; set; }
        public double? Poids { get; set; }
        public string Sexe { get; set; }
        public string Matricule { get; set; } // Rempli Obligatoirement
        public DateTime? DateNaissance { get; set; }
    }

    public class PatientToExcel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Matricule { get; set; }
        public string Nationnalite { get; set; }
        public string Groupage { get; set; }
        public string Sexe { get; set; }
    }
}
