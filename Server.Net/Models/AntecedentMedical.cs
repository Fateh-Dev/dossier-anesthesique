using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public class AntecedentMedical : FullAuditedEntity
    {
        // TODO Fix DEPENDENCY INJECTION
        public AntecedentMedical() { }

        public Guid Id { get; set; } = Guid.NewGuid();
        public TypeAntecedent TypeAntecedent { get; set; }
        public string Description { get; set; }
        public string TypeAntecedentLabel { get; set; }
        public Guid PatientId { get; set; }
    }

    public class AntecedentMedicalReturnDto
    {
        public Guid Id { get; set; }
        public TypeAntecedent TypeAntecedent { get; set; }
        public string Description { get; set; }
        public string TypeAntecedentLabel { get; set; }
        public Guid PatientId { get; set; }
    }

    public enum TypeAntecedent
    {
        Autre,
        Allergie,
        Tabac,
        Alcool,
        Diabete,
        Poumans,
        CoeurVaisseaux,
        HTA,
        AppUrinaire,
        AppDifestif,
        Neurologie,
        TrHemstase,
        Familiaux,
    }
}
