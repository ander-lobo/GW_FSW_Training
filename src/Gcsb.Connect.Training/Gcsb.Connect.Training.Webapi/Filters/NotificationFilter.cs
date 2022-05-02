using Gcsb.Connect.Training.Application.Repositories.Notification;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System.Net;

namespace Gcsb.Connect.Training.Webapi.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly INotifications notifications;

        public NotificationFilter(INotifications notifications)
        {
            this.notifications = notifications;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (notifications.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var obj = JsonConvert.SerializeObject(notifications.Notifications);
                await context.HttpContext.Response.WriteAsync(obj);

                return;
            }

            await next();
        }
    }
}
