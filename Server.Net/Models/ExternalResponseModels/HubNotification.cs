public class HubNotification
{
    public HubNotification() { }
    public HubNotification(string module, string command, string data)
    {
        module = module;
        command = command;
        data = data;
    }
    public string module { get; set; }
    public string command { get; set; }
    public string data { get; set; }
}