using ChatApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Interfaces
{
    public interface IChatService
    {
        Task SendMessageAsync(ChatMessage message);
        void RegisterClient(string clientId, WebSocket socket);
    }
}
