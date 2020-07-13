using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscordBotTutorial
{
    public struct ConfigJSON
    {
        //this initializes the token for us
        [JsonProperty("token")]
        public string Token { get; private set; }

        //this initializes the prefix for us
        [JsonProperty("prefix")]
        public string CommandPrefix { get; private set; }
    }
}
