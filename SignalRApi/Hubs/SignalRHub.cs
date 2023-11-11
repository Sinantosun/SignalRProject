using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccsessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        SignalRContext context = new SignalRContext();

        public async Task SendCategoryCount()
        {
            var value = context.Categories.Count();
            await Clients.All.SendAsync("ReciveCategoryCount",value);
        }
    }
}
