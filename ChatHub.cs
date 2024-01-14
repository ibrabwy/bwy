using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    public async Task SendMessage(string toUser, string message)
    {
        // Send the message to the specified user
#pragma warning disable CS8602 // Dereference of a possibly null reference.
        await Clients.User(toUser).SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
#pragma warning restore CS8602 // Dereference of a possibly null reference.
    }

    public async Task SetUserName(string userName)
    {
        // Assign the user name to the connection's identity
        await Groups.AddToGroupAsync(Context.ConnectionId, userName);
    }
}
