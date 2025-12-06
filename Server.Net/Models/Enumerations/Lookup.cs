using System;
using System.Collections.Generic;
using Server.Net.Models.System;

namespace Server.Net.Models.Enumerations
{
    public class AppSettingsDto
    {
        public string AppName { get; set; }
        public Guid? IdUnite { get; set; }
        public string AnneeScolaire { get; set; }
        public string Children { get; set; }
        public bool IsFakeDb { get; set; }
    }

    public class RefEntity
    {
        public string Label { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class ModalData
    {
        public Guid Id { get; set; }
        public string Display { get; set; }
        public string Abreviation { get; set; }
        public string Type { get; set; }
        public string ExtraPropertie { get; set; }
    }

    public partial class LookUpDataViewer
    {
        public AppSettingsDto _Settings { get; set; }

        public List<ExternalEntity> _ExternalServers { get; set; }

        public List<ModalData> _Agents { get; set; }
        public List<ModalData> _Structures { get; set; }
        public List<ModalData> _Specialite { get; set; }

        public List<ModalData> _GradesScientifiques { get; set; }
        public List<ModalData> _Armes { get; set; }
        public List<ModalData> _TypeAnesthesie { get; set; }
        public List<ModalData> _Respirateurs { get; set; }
        public List<ModalData> _Grades { get; set; }
        public List<Default> _Defaults { get; set; }
    }
}
