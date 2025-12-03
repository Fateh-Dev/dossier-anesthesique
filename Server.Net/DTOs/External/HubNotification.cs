namespace Server.Net.DTOs.External
{
    public class HubNotification
    {
        public HubNotification() { }

        public HubNotification(string module, string command, string data)
        {
            this.module = module;
            this.command = command;
            this.data = data;
        }

        public string module { get; set; }
        public string command { get; set; }
        public string data { get; set; }
    }
}
