using Microsoft.AspNetCore.SignalR;

namespace StudyIOC.Hubs
{
    public class ChartHub : Hub
    {
        public async Task SendMessage(string guid)
        {


            string deneme = "bu bir grup deneme mesajıdır";
            
            await Clients.Group(guid).SendAsync("ReceiveMessage",deneme);

        }
        public async Task AddGroup(string guid)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, guid);

            await Clients.Group(guid).SendAsync("Send", $"{Context.ConnectionId} has joined the group {guid}.");

        }
    }
}
