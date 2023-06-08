using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WordPuzzle.Models;

namespace WordPuzzle.Controllers
{
  public class GameController : Controller
  {
    [HttpGet("/game")]
    public ActionResult Index()
    {
      Game currentGame = Game.CurrentGame;
      return View(currentGame);
    }
    
    [HttpPost("/game")]
    public ActionResult Create()
    {
      Game newGame = new Game(Game.RandomWord());
      return RedirectToAction("Index");
    }

    [HttpPost("game/guess")]
    public ActionResult Guess(char guess)
    {
      guess = Char.ToLower(guess);
      if (!Game.CurrentGame.IsGuessed(guess))
      {
        Game.CurrentGame.AddGuess(guess);

        if (Game.CurrentGame.IsInWord(guess))
        {
          foreach (Dictionary<char, bool> dict in Game.CurrentGame.CharGuessed)
          {
            foreach (var character in dict)
            {
              if (character.Key == guess)
              {
                dict[guess] = true;
              }
            }
          }
        }
        else
        {
          Game.CurrentGame.Lives--;
        }
      }
      return RedirectToAction("Index");
    }
  }
}