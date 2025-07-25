using ChatApp.API.Middleware;
using ChatApp.Application.Interfaces;
using ChatApp.Infrastructure.Services;
using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add WebSocket support
builder.Services.AddWebSockets(options => { });
builder.Services.AddSingleton<IChatService, ChatService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//Register middleware UseMiddleware<WebSocketManager>() after UseWebSockets() and before UseRouting()

app.UseWebSockets();
app.UseMiddleware<ChatApp.API.Middleware.WebSocketManager>();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
