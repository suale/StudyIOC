using Microsoft.AspNetCore.SignalR;
using StudyIOC.ServiceModels;
using StudyIOC.Services;

namespace StudyIOC.Hubs
{
    public class ChartHub : Hub
    {
        public async Task SendMessage(string guid)
        {
            string saat = DateTime.Now.ToString();
            List<RabbitMessage> chartMessage = new List<RabbitMessage>();
            for (int i = 0; i < Consumer.rabbitMessages.Count; i++)
            {
                if (Consumer.rabbitMessages[i].ClientGUID == guid)
                {
                    chartMessage.Add(Consumer.rabbitMessages[i]);
                    
                }

            }
            //RabbitMessage gidecek = chartMessage[chartMessage.Count - 1];

            string gidecek = "bu bir grup deneme mesajıdır "+ guid+ " "+ saat;
            
            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage",gidecek);

        }
        public async Task AddGroup(string guid)
        {

            await Groups.AddToGroupAsync(Context.ConnectionId, guid);

            await Clients.Group(guid).SendAsync("Send", $"{Context.ConnectionId} has joined the group {guid}.");

        }
    }
}
