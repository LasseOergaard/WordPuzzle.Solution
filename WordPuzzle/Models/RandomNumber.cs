using System;

namespace WordPuzzle.Models
{
  public class RandomNumber
  {
    public static Random rnd = new Random();

    public static int Get(int max)
    {
      return rnd.Next(max);
    }
    public static int Get(int min, int max)
    {
      return rnd.Next(min, max);
    }
  }
}