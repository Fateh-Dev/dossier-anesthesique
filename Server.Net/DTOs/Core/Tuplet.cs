namespace Server.Net.DTOs.Core
{
    public class Tuplet
    {
        public double? TotalPlanified { get; set; }
        public int TotalExecuted { get; set; }

        public Tuplet(double TotalPlanified, double TotalExecuted)
        {
            TotalPlanified = TotalPlanified;
            TotalExecuted = TotalExecuted;
        }
    }

    public class AppSettingsFile
    {
        public bool isFake { get; set; }
    }
}
