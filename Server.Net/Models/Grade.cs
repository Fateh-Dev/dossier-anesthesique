using System;
using System.Collections.Generic;

namespace Server.Net
{
    public partial class Grade
    {
        public Grade(string label, string Abreviation, int order)
        {
            Id = Guid.NewGuid();
            this.Label = label;
            this.Abreviation = Abreviation;
            this.Order = order;
        }

        public Guid Id { get; set; }
        public string Label { get; set; }
        public string Abreviation { get; set; }
        public int Order { get; set; }
    }
}
