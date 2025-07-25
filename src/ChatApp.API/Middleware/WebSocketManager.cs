using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using ChatApp.Infrastructure.Services;
using System.Linq;
using System.Net.WebSockets;
using System.Text;

namespace ChatApp.API.Middleware
{
    // Middleware/WebSocketManager.cs
    public class WebSocketManager(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context, IChatService chatService)
        {
            if (context.Request.Path.StartsWithSegments("/ws") && context.WebSockets.IsWebSocketRequest)
            {
                Console.WriteLine($"➡️ Request path: {context.Request.Path}");
                Console.WriteLine($"🧪 IsWebSocketRequest: {context.WebSockets.IsWebSocketRequest}");
                string clientId = context.Request.Query["clientId"]!;
                var socket = await context.WebSockets.AcceptWebSocketAsync();

                chatService.RegisterClient(clientId, socket);

                var buffer = new byte[1024 * 4]; 

                while (socket.State == WebSocketState.Open)
                {
                    var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                    if (result.CloseStatus.HasValue) break;

                    string msg = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    var chatMsg = new ChatMessage
                    {
                        Sender = clientId,
                        Content = msg.StartsWith("@") ? string.Join(" ", msg.Split(' ')[1..]) : msg,
                        Receiver = msg.StartsWith("@") ? msg.Split(' ')[0][1..] : ""
                    };

                    await chatService.SendMessageAsync(chatMsg);
                }

                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closed", CancellationToken.None);
            }
            else if (context.Request.Path.StartsWithSegments("/ws"))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("WebSocket connection expected.");
            }
            else
            {
                await next(context);
            }
        }
    }
}
