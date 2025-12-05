using Server.Net.Models.Enumerations;

namespace Server.Net.Services
{
    public static class UserDivisionEcoleAppService
    {
        public static bool isFake { get; set; } = false;
        public static LookUpDataViewer lookups { get; set; }
    }
}
