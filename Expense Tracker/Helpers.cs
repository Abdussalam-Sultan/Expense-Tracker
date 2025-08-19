using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Helpers
    {
        public static int EnumSelector(string text, int validStart, int validEnd)
        {
            int choice;
            do
            {
                Console.WriteLine($"{text} ({validStart}-{validEnd}): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out choice) && choice >= validStart && choice <= validEnd)
                {
                    return choice;
                }
                Console.WriteLine($"Invalid input. Please enter a number between {validStart} and {validEnd}.");
            } while (true);
        }
        public static void PrintHeader()
        {
            Console.WriteLine("Expense Tracker");
            Console.WriteLine("=========================================");
            Console.WriteLine("ID    Date       Category      Amount     Note");
            Console.WriteLine("-----------------------------------------");
        }
        public static void PrintFooter(int count)
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"Total Expenses: {count}");
            Console.WriteLine("=========================================");
        }
        public static void PrintCategories()
        {
            Console.WriteLine(@"Select a category for the expense: 
1.Food      2.Transport 3.Entertainment
4.Utilities 5.Health    6.Education
5.Shopping  6.Other");
        }
    }
}
