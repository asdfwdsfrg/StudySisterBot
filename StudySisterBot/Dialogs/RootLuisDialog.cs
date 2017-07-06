using StudySisterBot.Controllers;
using System;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Dialogs;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis.Models;
using System.Collections.Generic;
using StudySisterBot.Controllers;


namespace StudySisterBot.Dialogs
{
    [LuisModel("af995f23-f3fa-42f2-800f-179578b2e585", "8e451d761a18455eaf4ba8ed5fc23a47")]
    [Serializable]
    public class RootLuisDialog : LuisDialog<object>
    {
        public bool iserror(DBController.ResultData e)
        {
            return e.type == "error";
        }


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
            if (result.Entities.Count < 1)
            {
                var message = await activity;
                await context.PostAsync("呀呀呀没找到呀！");
            }
            else if (result.Entities.Count == 1)
            {
                string e1 = "";
                foreach (var each in result.Entities)
                {
                    foreach (var v in each.Resolution.Values) e1 = v.ToString();
                    if(e1 != null)
                        e1 = e1.Split('\"')[1];
                }
                var obj = DBController.GetObject("relations?entity=西安电子科技大学&relation=" + e1);
                if (!iserror(obj))
                {
                    string s = obj.result;
                    var message = await activity;
                    await context.PostAsync(s);
                }
                else
                {
                    var message = await activity;
                    await context.PostAsync("抱歉没找到哦~");
                }
            }
            else
            {
                string e2 = "";
                string e1="";
                foreach (var each in result.Entities)
                {
                    if (each.Type == "学院" || each.Type == "部门")
                    {
                        foreach (var v in each.Resolution.Values) e1 = v.ToString();
                        e2 = e2.Split('\"')[1];
                    }
                    else
                    {
                        foreach (var v in each.Resolution.Values) e2 = v.ToString();
                        e2 = e2.Split('\"')[1];
                    }
                }
                var obj = DBController.GetObject("relations?entity=" + e1 + "&relation=" + e2);
                if (!iserror(obj))
                {
                    string s = obj.result;
                    var message = await activity;
                    await context.PostAsync(s);
                }
                else
                {
                    var message = await activity;
                    await context.PostAsync("抱歉没找到哦~");
                }

            }

        }

        [LuisIntent("QueryAttribution")]
        public async Task QueryAttribution(IDialogContext context, IAwaitable<IMessageActivity> activity, LuisResult result)
        {
            if (result.Entities.Count < 1)
            {
                var message = await activity;
                await context.PostAsync("呀呀呀没找到呀！");
            }
            else if (result.Entities.Count == 1)
            {
                string e1 = "";
                foreach (var each in result.Entities)
                {
                    foreach (var v in each.Resolution.Values) e1 = v.ToString();
                    e1 = e1.Split('\"')[1];
                }
                var obj = DBController.GetObject("relations?entity=西安电子科技大学&relation=" + e1);
                if (!iserror(obj))
                {
                    string s = obj.result;
                    var message = await activity;
                    await context.PostAsync(s);
                }
                else
                {
                    var message = await activity;
                    await context.PostAsync("抱歉没找到哦~");
                }
            }
            else
            {
                string e2 = "";
                string e1 = "";
                foreach (var each in result.Entities)
                {
                    if (each.Type == "学院" || each.Type == "部门")
                    {
                        foreach (var v in each.Resolution.Values) e1 = v.ToString();
                        e1 = e1.Split('\"')[1];
                    }
                    else
                    {
                        foreach (var v in each.Resolution.Values) e2 = v.ToString();
                        e2 = e2.Split('\"')[1];
                    }
                }
                var obj = DBController.GetObject("relations?entity=" + e1 + "&relation=" + e2);
                if (!iserror(obj))
                {
                    string s = obj.result;
                    var message = await activity;
                    await context.PostAsync(s);
                }
                else
                {
                    var message = await activity;
                    await context.PostAsync("抱歉没找到哦~");
                }
            }
            }
        }
}