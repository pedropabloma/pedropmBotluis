using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tweetinvi.Core.Interfaces;

namespace BotAndLuisDemo
{
    [LuisModel("pon la tuya", "pon la tuya")]
    [Serializable]
    public class TwitterDialog : LuisDialog<object>
    {
        [LuisIntent("")] //None
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry I did not understand. Could you repeat?";
            await context.PostAsync(message);
            context.Wait(MessageReceived);
        }

        [LuisIntent("Greetings")]
        public async Task Greetings(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Como estas ! , estan son mis opciones : ");
            await context.PostAsync("puedo buscar un perfil en Twitter, utiliza: 'busca'");
            await context.PostAsync("y puedo buscar en hashtags, utiliza: 'que pasa sobre'");
            await context.PostAsync("ah, además se decir 'Hola' :-)");
            // await context.PostAsync("!(http://aka.ms/Fo983c)");
            // await context.PostAsync("Cuac!");
            // await context.PostAsync("![duck](http://img.glimboo.com/smiles/0011.gif)");

            context.Wait(MessageReceived);
        }

        [LuisIntent("SearchUser")]
        public async Task SearchUser(IDialogContext context, LuisResult result)
        {
            if (result.Entities.Count > 0)
            {

                var userName = result.Entities[0].Entity;

                try
                {
                    await context.PostAsync(string.Format("This is what **{0}** says: ", userName));
                    var user = TwitterService.GetUser(userName);
                    await context.PostAsync(string.Format("![userName]({0})", user.ProfileImageUrl400x400));
                    await context.PostAsync(user.Description);

                }
                catch (Exception ex)
                {
                    await context.PostAsync(ex.Message);
                }
            }
            else
            {
                await context.PostAsync("Wait, what?");
            }

            context.Wait(MessageReceived);
        }


        [LuisIntent("SearchKeyword")]
        public async Task SearchKeyword(IDialogContext context, LuisResult result)
        {
            if (result.Entities.Count > 0)
            {

                IEnumerable<ITweet> tweets = TwitterService.GetKeyword(result.Entities[0].Entity);

                foreach (var tweet in tweets)
                {
                    await context.PostAsync(tweet.Text);
                }
            }
            else
            {
                await context.PostAsync("Wait what?");
            }

            context.Wait(MessageReceived);
        }
    }
}
