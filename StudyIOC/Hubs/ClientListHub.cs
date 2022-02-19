using Microsoft.AspNetCore.SignalR;
using StudyIOC.Services;
using System.Globalization;

namespace StudyIOC.Hubs
{
    public class ClientListHub : Hub
    {
        public async Task SendMessage()
        {
            

            var clientNolar = Consumer.rabbitMessagesClientList
                             .GroupBy(o => new { o.ClientGUID })
                             .Select(o => o.LastOrDefault());

            var clientNos = clientNolar.ToList();

    
            for (int i = clientNos.Count - 1; i >= 0; i--)
            {
                var value = DateTime.Parse(clientNos[i].timestamp);
                var value2 = DateTime.Now.AddSeconds(-4);
                if (DateTime.Compare(value, value2) < 0)
                {
                    clientNos.RemoveAt(i);
                }
            }
            await Clients.Caller.SendAsync("ReceiveMessage", clientNos);

        }
    }
}
