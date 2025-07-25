using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChatApp.API.Models;

namespace ChatApp.API.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // GET: /Home/Chat?clientId=Client1
    public IActionResult Chat(string clientId)
    {
        if (string.IsNullOrWhiteSpace(clientId))
        {
            // You can return a validation error or redirect to Index
            TempData["Error"] = "Please select a valid client.";
            return RedirectToAction("Index");
        }

        ViewData["ClientId"] = clientId;
        return View();
    }
}
