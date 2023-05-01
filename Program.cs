using DSharpPlus;
namespace CalaFirstBot
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "test",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            });

            discord.MessageCreated += async (s, e) =>
            {
                var message = e.Message.Content.ToLower();
                bool messageModified = false;

                if (message != null && !e.Message.Author.IsBot)
                {
                    if (message.EndsWith("o"))
                    {
                        message = message.Substring(0, message.Length - 1) + "a";
                        messageModified = true;
                        //await e.Message.RespondAsync(response);
                        
                    }
                    else if (message.EndsWith("a"))
                    {
                        message = message.Substring(0, message.Length - 1) + "o";
                        messageModified = true;
                        //await e.Message.RespondAsync(response);
                    }
                    else if (message.StartsWith("ping"))
                    {
                        await e.Message.RespondAsync("pong!");
                    }

                    if(messageModified)
                    {
                        //messageModified = false;
                        await e.Message.RespondAsync(message);
                    }
                }
            };
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
