using System.Collections.Generic;
using System;

namespace WordPuzzle.Models
{
  public class Game
  {
    public string Word { get; set; }
    public List<Dictionary<char, bool>> CharGuessed = new List<Dictionary<char, bool>> { };
    public List<char> Guesses = new List<char> { };
    public static Game CurrentGame { get; set; }
    public int Lives { get; set; }


    public Game(string word)
    {
      Lives = 5;
      Word = word;
      CurrentGame = this;
      foreach (char letter in Word)
      {
        Dictionary<char, bool> myDict = new Dictionary<char, bool> { };
        myDict.Add(letter, false);
        CharGuessed.Add(myDict);
      }
    }

    public void AddGuess(char guess)
    {
      Guesses.Add(guess);
    }

    public bool IsInWord(char guess)
    {
      if (Word.Contains(guess))
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public static string RandomWord()
    {

      List<string> wordList = new List<string> {
        "ipohne", "guitarplayer", "Whiteboard", "pigeon", "smiley"
        };

      return wordList[RandomNumber.Get(5)];
    }

    public bool IsGuessed(char guess)
    {
      return Guesses.Contains(guess);
    }
  }
}