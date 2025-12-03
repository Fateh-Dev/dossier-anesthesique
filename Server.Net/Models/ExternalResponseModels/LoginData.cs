using System;
using System.Collections.Generic;

namespace Server.Net
{
    public class LoginData
    {
        public string access_Token { get; set; }
        public int expires_in { get; set; }
        public string token_type { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
    }

    public class ReturnedNotif
    {
        public string Response { get; set; }
        public AppNotification ResNotification { get; set; }
    }
}
