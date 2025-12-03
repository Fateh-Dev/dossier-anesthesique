using System;
using Server.Net.Models.Enumerations;

namespace Server.Net.Models.System
{
    public class AppNotification : FullAuditedEntity
    {
        public int UserIds { get; set; }
        public string Data { get; set; }
        public string DataTypeName { get; set; }
        public string Url { get; set; }
        public StatusNotification Status { get; set; }
        public TypeNotification Type { get; set; }
        public string NotificationName { get; set; }
        public string Distination { get; set; }
        public string Payload { get; set; }
        public string ExcludedUserIds { get; set; }
        public string EntityTypeName { get; set; }
        public bool Read { get; set; }
        public int Severity { get; set; }
        public Guid? EntityId { get; set; }
        public string EntityTypeAssemblyQualifiedName { get; set; }
    }
}
