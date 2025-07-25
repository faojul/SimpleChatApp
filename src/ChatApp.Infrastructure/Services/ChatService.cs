using ChatApp.Application.Interfaces;
using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        private readonly Dictionary<string, WebSocket> _clients = new();
        public void RegisterClient(string clientId, WebSocket socket)
        {
            _clients[clientId] = socket;
        }
        public async Task SendMessageAsync(ChatMessage message)
        {
            string formatted = $"{message.Timestamp:HH:mm} [{message.Sender}] => {message.Content}";
            byte[] buffer = Encoding.UTF8.GetBytes(formatted);

            if (!string.IsNullOrEmpty(message.Receiver) && message.Receiver != "All")
            {
                // Private
                if (_clients.TryGetValue(message.Receiver, out var ws) && ws.State == WebSocketState.Open)
                    await ws.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
            }
            else
            {
                // Public
                foreach (var socket in _clients.Values.Where(s => s.State == WebSocketState.Open))
                {
                    await socket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
                }
            }
        }
    }
}
