using System;

namespace Server.Net.Models.Reference
{
    public partial class Specialite
    {
        public Specialite() { }

        public Specialite(string label, string abreviation, string description)
        {
            this.Id = Guid.NewGuid();
            this.Label = label;
            this.Abreviation = abreviation;
            this.Description = description;
        }

        public Specialite(string label, string abreviation, int order)
        {
            this.Id = Guid.NewGuid();
            this.Label = label;
            this.Abreviation = abreviation;
            this.Order = order;
        }

        public Specialite(string label, string abreviation)
        {
            this.Id = Guid.NewGuid();
            this.Label = label;
            this.Abreviation = abreviation;
        }

        public Guid Id { get; set; }
        public string Abreviation { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}
