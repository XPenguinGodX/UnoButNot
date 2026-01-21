using System;
using System.Diagnostics;
using UnoButNot.modules;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var game = new Uno();
            game.StartGame();
        }
    }
}