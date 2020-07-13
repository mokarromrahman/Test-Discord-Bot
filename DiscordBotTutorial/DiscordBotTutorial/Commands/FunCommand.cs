using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBotTutorial.Commands
{
    public class FunCommand: BaseCommandModule
    {
        [Command("ping")]
        [Description("Bot will say pong.")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }

        [Command("add")]
        [Description("Adds 2 numbers together separated by a space.\nFor example: '?add 1 2'")]
        public async Task Add (CommandContext ctx, 
            [Description("First number")] int num1,
            [Description("Second number")]  int num2)
        {
            await ctx.Channel.SendMessageAsync((num1 + num2).ToString()).ConfigureAwait(false);
        }
    }
}
