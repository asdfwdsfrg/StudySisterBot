using System;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis.Models;

namespace StudySisterBot.Dialogs
{
    [LuisModel("af995f23-f3fa-42f2-800f-179578b2e585", "8e451d761a18455eaf4ba8ed5fc23a47")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {

        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = "你在说啥呢兄弟，听不懂";
            await context.PostAsync(message);
            context.Wait(this.MessageReceived);
        }

        [LuisIntent("QueryPeople")]
        public async Task QueryPeople(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            var entities = result.Entities;
            string s = "";
                foreach (var i in entities) {
                s += i.Entity;
                }
                
                   
            var message = await activity;
            await context.PostAsync(s);
        }

        [LuisIntent("QueryAttribution")]
        public async Task QueryAttribution(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            
            var message = await activity;
            await context.PostAsync("You QueryAttribution");        
        }
    }
}