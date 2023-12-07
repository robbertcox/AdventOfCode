// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;

Console.WriteLine("Hello, World!");
var gameNumber = 1;

var maxBlue = 14;
var maxGreen = 13;
var maxRed = 12;
var sum = 0;
var part2 = 0;
foreach (var line in File.ReadAllLines("../../../Input.txt"))
{
    var red = 0; var green = 0; var blue = 0;


    var line1 = line.Substring(line.IndexOf(':') + 2);
    string[] games = line1.Split(';');
    var valid = true;
    foreach (var game in games)
    {
        foreach (var item in game.Split(","))
        {
            int digit = int.Parse(string.Concat(item.Where(Char.IsDigit)));
            if (item.Contains("red"))
            {
                red = red < digit ? digit : red;
                valid = false;
            }
            if (item.Contains("blue"))
            {
                blue = blue < digit ? digit : blue;
                valid = false;
            }
            if (item.Contains("green"))
            {
                green = green < digit ? digit : green;
                valid = false;
            }
        }

        Console.WriteLine(game);
    }
    if (valid)
        sum += gameNumber;
    gameNumber++;
    part2 += (red * blue * green);
}
Console.WriteLine($"{sum}:{part2}");