using System;
using System.Collections.Generic;

namespace Server.Net
{
    public partial class DeroulementOperatoire
    {
        public DeroulementOperatoire() { }

        public Guid Id { get; set; }
        public string Temps { get; set; }
        public Guid InterventionId { get; set; }
        public int? Temperature { get; set; }
        public int? FrequenceCardiaque { get; set; }
        public int? PressionArterielleMin { get; set; }
        public int? PressionArterielleMax { get; set; }
        public int? Diurese { get; set; }
        public int? Saignement { get; set; }
        public string TempsOperatoire { get; set; }
        public string Agent { get; set; }
        public double? AgentValue { get; set; }

        // public ICollection<AgentAnesthesique> AgentsAnesthesiques { get; set; }
        public bool? ApportsCG { get; set; }
        public bool? ApportsPFC { get; set; }
        public bool? ApportsPlasm { get; set; }
        public bool? ApportsGluc { get; set; }
        public bool? ApportsSale { get; set; }
        public string PO2 { get; set; }
        public string PCO2 { get; set; }
        public string PH { get; set; }
        public string HCO3 { get; set; }
        public string Sat { get; set; }
        public string Ht { get; set; }
        public string FIO2 { get; set; }
        public string N2O { get; set; }
        public string Air { get; set; }
        public string V { get; set; }
        public string Vt { get; set; }
        public string F { get; set; }
        public string Sevo { get; set; }
        // TODO We Need to Add More Details about Agents and PO2 PCO2
    }

    public partial class DeroulementOperatoireCreateDto
    {
        public DeroulementOperatoireCreateDto() { }

        public Guid Id { get; set; }
        public string Temps { get; set; }
        public Guid InterventionId { get; set; }
        public int? Temperature { get; set; }
        public int? FrequenceCardiaque { get; set; }
        public int? PressionArterielleMin { get; set; }
        public int? PressionArterielleMax { get; set; }
        public int? Diurese { get; set; }
        public int? Saignement { get; set; }
        public string TempsOperatoire { get; set; }
        public string Agent { get; set; }
        public double? AgentValue { get; set; }
        public ICollection<AgentAnesthesique> AgentsAnesthesiques { get; set; }
        public bool? ApportsCG { get; set; }
        public bool? ApportsPFC { get; set; }
        public bool? ApportsPlasm { get; set; }
        public bool? ApportsGluc { get; set; }
        public bool? ApportsSale { get; set; }
        public string PO2 { get; set; }
        public string PCO2 { get; set; }
        public string PH { get; set; }
        public string HCO3 { get; set; }
        public string Sat { get; set; }
        public string Ht { get; set; }
        public string FIO2 { get; set; }
        public string N2O { get; set; }
        public string Air { get; set; }
        public string V { get; set; }
        public string Vt { get; set; }
        public string F { get; set; }
        public string Sevo { get; set; }
        // TODO We Need to Add More Details about Agents and PO2 PCO2
    }
}
