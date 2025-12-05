using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities;

namespace Server.Net.Models.System
{
    public class Default : Entity<Guid>
    {
        public string Profile { get; set; }
        public string NiveauScolaire { get; set; }
        public string TypeAeronefLabel { get; set; }
        public string Timing { get; set; }
        public Guid IdUnite { get; set; }
    }
}
