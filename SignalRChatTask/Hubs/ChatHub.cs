using Microsoft.AspNetCore.SignalR;

namespace SignalRChatTask.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendToUser(string user, string receiverConnectionId, string message)
        {
            await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", user, message);
        }

        public string GetConnectionId() => Context.ConnectionId;
    }
}
