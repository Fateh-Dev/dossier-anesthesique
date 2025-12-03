using System;
using Microsoft.EntityFrameworkCore;

namespace Server.Net.Models.System
{
    public class AppSetting : FullAuditedEntity
    {
        public string AppName { get; set; }
        public Guid? IdUnite { get; set; }
        public string? Children { get; set; }
        public string AnneeScolaire { get; set; }
        public bool IsFakeDb { get; set; }

        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppSetting>(entity =>
            {
                entity.HasQueryFilter(m => m.IsDeleted == false);
            });
        }
    }
}
