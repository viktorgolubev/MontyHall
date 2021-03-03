using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHall.Models
{
    public class Displayer
    {
        public static void GameState(Game game)
        {
            foreach (var door in game.Doors)
            {
                Console.BackgroundColor = GetColor(door);
                char sign = door.IsSelected ? 'V' : ' ';
                Console.Write($"[{sign}]");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" ");
            }
            Console.Write("     ");
        }

        public static void GameResult(Game game)
        {
            Console.BackgroundColor = game.IsCorrectGuess()
                ? ConsoleColor.DarkGreen
                : ConsoleColor.Red;

            Console.Write("              ");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(" ");
        }

        private static ConsoleColor GetColor(Door door)
        {
            if (door.IsOpened)
            {
                return door.ContainsPrize
                    ? ConsoleColor.DarkGreen
                    : ConsoleColor.Yellow;
            }

            return ConsoleColor.Black;
        }
    }
}
