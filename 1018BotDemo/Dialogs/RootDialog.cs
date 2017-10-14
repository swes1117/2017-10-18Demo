using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Collections.Generic;

namespace _1018BotDemo.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var reply = activity.CreateReply();
            reply.Attachments = new List<Attachment>();

            if(activity.Text.StartsWith("West brook"))
            {
                reply.Attachments.Add(new Attachment()
                {
                    ContentUrl = "https://www.google.com.tw/search?q=Westbrook&source=lnms&tbm=isch&sa=X&ved=0ahUKEwiE7qPOue_WAhVCFJQKHeMzDqIQ_AUICigB&biw=1536&bih=759#imgrc=yxfYZZq5M5e7XM:",
                    ContentType = "image/png",
                    Name = "Westbrook"
                });
            }

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            await context.PostAsync(reply);

            context.Wait(MessageReceivedAsync);
        }
    }
}