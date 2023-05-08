using System;
using System.Collections.Generic;
using System.Text;

namespace Parking.library
{
    public static class ConsoleHeader
    {
        public static int BlackValue()
        {
            return (int)(ConsoleColor.Black);
        }
        public static void Header(string str, char symbol = '-', ConsoleColor color = (ConsoleColor)(15), ConsoleColor headeColor = (ConsoleColor)(15))
        {
            Header(str, symbol, symbol, color, headeColor);
        }

        public static void Header(string str, char leftSymbol, char rightSymbol, ConsoleColor color)
        {
            Header(str, leftSymbol, rightSymbol, color, color);
        }

        public static void Header(string str, char leftSymbol, char rightSymbol, ConsoleColor color, ConsoleColor headerColor)
        {
            int windowWidth = Console.WindowWidth;
            int count = (windowWidth - str.Length - 2) / 2;
            Console.ForegroundColor = color;
            Console.Write(new string(leftSymbol, count) ?? "");
            Console.ForegroundColor = headerColor;
            Console.Write(" " + str + " ");
            Console.ForegroundColor = color;
            Console.WriteLine(new string(rightSymbol, count) + "\n");
            Console.ForegroundColor = (ConsoleColor)(15);
        }
    }
}
