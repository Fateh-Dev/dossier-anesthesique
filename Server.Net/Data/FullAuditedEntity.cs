using System;
using Microsoft.EntityFrameworkCore;

namespace Server.Net
{
    public class FullAuditedEntity
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
