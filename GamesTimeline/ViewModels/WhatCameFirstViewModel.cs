using IGDB.Models;

namespace GamesTimeline.ViewModels;

public class WhatCameFirstViewModel
{
    public Game Game1 { get; set; }
    public string gameCoverUrl { get; set; }
    public Game Game2 { get; set; }
    public string game2CoverUrl { get; set; }
    public int Score { get; set; } = 0;
    
}