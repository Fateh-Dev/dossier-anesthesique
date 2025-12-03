using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Net
{
    public partial class ExternalEntity
    {
        public ExternalEntity() { }

        public ExternalEntity(
            string serverName,
            string address,
            int port,
            LoginData loginRes,
            string description,
            string user,
            string password
        )
        {
            this.ServerUrl = "http://" + address + ":" + port.ToString();
            this.Address = address;
            this.Port = port;

            this.ServerName = serverName;
            this.Access_Token = loginRes.access_Token;
            this.Expires_in = loginRes.expires_in;
            this.Token_type = loginRes.token_type;
            this.Refresh_token = loginRes.refresh_token;
            this.Scope = loginRes.scope;
            this.Description = description;
            this.DefaultUser = user;
            this.DefaultPassword = password;
        }

        public ExternalEntity(
            string serverName,
            string server,
            LoginData loginRes,
            string description,
            string user,
            string password
        )
        {
            this.ServerUrl = "http://" + server;
            this.Address = server.Split(":")[0];
            this.Port = Int32.Parse(server.Split(":")[1]);

            this.ServerName = serverName;
            this.Access_Token = loginRes.access_Token;
            this.Expires_in = loginRes.expires_in;
            this.Token_type = loginRes.token_type;
            this.Refresh_token = loginRes.refresh_token;
            this.Scope = loginRes.scope;
            this.Description = description;
            this.DefaultUser = user;
            this.DefaultPassword = password;
        }

        [Key]
        public string ServerName { get; set; }
        public string ServerUrl { get; set; }
        public string Address { get; set; }
        public int Port { get; set; }
        public string Access_Token { get; set; }
        public int Expires_in { get; set; }
        public string Token_type { get; set; }
        public string Refresh_token { get; set; }
        public string Scope { get; set; }
        public string Description { get; set; }
        public string DefaultUser { get; set; }
        public string DefaultPassword { get; set; }
    }
}
