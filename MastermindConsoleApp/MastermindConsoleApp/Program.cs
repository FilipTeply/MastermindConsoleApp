using MastermindConsoleApp.Models;
using System;

namespace MastermindConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, are you up for some Mastermind fun?");

            Game game = new Game();

            game.PlayTheGame();
        }
    }
}
