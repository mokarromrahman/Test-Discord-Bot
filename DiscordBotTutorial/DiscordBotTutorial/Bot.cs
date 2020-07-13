using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace DiscordBotTutorial
{
    public class Bot
    {
        //Current discord client being used
        public DiscordClient DiscordClient { get; private set; }

        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            //hold the json variables
            string json = "";

            //open and read the config.json file
            using (FileStream fs = File.OpenRead("config.json"))
            {
                using(StreamReader sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    //false makes it so that the same thread does not
                    //have to continue the task
                    json = await sr.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            //conver the string into this object
            ConfigJSON configJson = JsonConvert.DeserializeObject<ConfigJSON>(json);

            //instantiate with the configs we need
            DiscordConfiguration discordConfiguration = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            //create new client with the configs
            DiscordClient = new DiscordClient(discordConfiguration);

            DiscordClient.Ready += OnClientReady;


            //Set the commands
            CommandsNextConfiguration cnc = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { configJson.CommandPrefix },
                EnableDms = false,
                //Allows you to say @Bot command
                EnableMentionPrefix = true
            };

            Commands = DiscordClient.UseCommandsNext(cnc);

            await DiscordClient.ConnectAsync();

            //Set a delay so that the bot does not quit
            await Task.Delay(-1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask; 
        }
    }
}
