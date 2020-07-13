using System;

namespace DiscordBotTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Bot bot = new Bot();
            try
            {
                bot.RunAsync().GetAwaiter().GetResult();
            }
            catch(Exception e)
            {
                
            }
        }
    }
}
