using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GamesTimeline.Models;
using IGDB;
using IGDB.Models;

namespace GamesTimeline.Controllers;

public class HomeController : Controller
{
    private readonly IConfiguration _config;
    private readonly IGDBClient _igdbClient;
    public HomeController(IConfiguration config)
    {
        _config = config;
        
        _igdbClient = IGDBClient.CreateWithDefaults(
            // Found in Twitch Developer portal for your app
            _config["IGDB_CLIENT_ID"],
            _config["IGDB_CLIENT_SECRET"]
        );
    }
    
    public async Task<IActionResult> Index()
    {
        var games = await _igdbClient.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: "fields *;");
        var game = games.First();
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
}