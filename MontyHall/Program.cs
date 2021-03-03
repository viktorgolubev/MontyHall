using MontyHall.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MontyHall
{
    class Program
    {
        static void Main(string[] args)
        {
            List<bool> gamesResults = new List<bool>();

            for (var i = 0; i < 100; i++)
            {
                Game game = new Game();
                game.SelectDoor();
                Displayer.GameState(game);
                game.OpenEmptyNotSelectedDoor();
                Displayer.GameState(game);
                game.ReselectDoor();
                Displayer.GameState(game);
                game.OpenPrizeDoor();
                Displayer.GameState(game);
                Displayer.GameResult(game);

                gamesResults.Add(game.IsCorrectGuess());

                Console.WriteLine();
            }

            int won = gamesResults.Count(x => x);
            int lost = gamesResults.Count(x => !x);

            Console.WriteLine();
            Console.WriteLine($"You have won {won} times and lost {lost} times.");
        }
    }
}
