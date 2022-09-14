
using Microsoft.AspNetCore.SignalR;

namespace IP_Projekt.Hubs
{
    public class ChatHub:Hub
    {
        // tutaj mozna doda usera do wiadomosci
        public async Task SendMessage( string message)
        {
            await Clients.All.SendAsync("ReceiveMessage",  message);
        }

    }
}
