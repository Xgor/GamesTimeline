using GamesTimeline.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IGDB;
using IGDB.Models;

namespace GamesTimeline.Controllers;


public class GamesController : Controller
{
    // GET: GamesController
    private readonly IConfiguration _config;
    private readonly IGDBClient _igdbClient;

    public const int GAMES_COUNT = 375811; // Get this dynamic later
    public GamesController(IConfiguration config)
    {
        _config = config;
        
        _igdbClient = IGDBClient.CreateWithDefaults(
            // Found in Twitch Developer portal for your app
            _config["IGDB_CLIENT_ID"], 
            _config["IGDB_CLIENT_SECRET"]);
    }

    public async Task<ActionResult> Index()
    {
        var game = await GetRandomGameAsync();
        var game2 = await GetRandomGameAsync();
   
        var viewModel = new WhatCameFirstViewModel()
        {
            Game1 = game,
            Game2 = game2
        };
        return View(viewModel);
    }

    public async Task<ActionResult> Results(DateTimeOffset game1,DateTimeOffset game2, string choice)
    {
        bool correct = false;
        switch (choice)
        {
            case "1":
                correct = game1 < game2;
                break;
            case "2":
                correct = game2 < game1;
                break;  
        }
        TempData["Message"] = correct ? "Correct" : "Incorrect";
        
        return RedirectToAction(nameof(Index));
    }
    
    
    
    public async Task<Game> GetRandomGameAsync()
    {
        var rng = new Random().Next(0, GAMES_COUNT);
        Game? game = null;
        do
        {
            var games = await _igdbClient.QueryAsync<Game>(IGDBClient.Endpoints.Games, query: $"fields name,first_release_date; where id = {rng};");
            game = games.FirstOrDefault();
        } while (game == null);

        return game;
    }
}
