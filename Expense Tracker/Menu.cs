using Expense_Tracker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Menu
    {
        private static IExpenseService expenseService = new ExpenseService();
        public static void MainMenu()
        {
            try
            {

                bool isRunning = true;
                while (isRunning)
                {
                    PrintMenu();
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            expenseService.AddExpense();
                            break;
                        case "2":
                            expenseService.ViewExpenses();
                            break;
                        case "3":
                            expenseService.GetSummary();
                            break;
                        case "4":
                            expenseService.SearchExpenses();
                            break;
                        case "0":
                            isRunning = false;
                            break;
                        default:
                            Helpers.Failure("Invalid choice, please try again.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Helpers.Failure(ex.Message);
                Console.WriteLine("Click enter to continue...");
                Console.ReadLine();
                MainMenu();
            }
        }
        public static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Expense Tracker Menu");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Get Summary of Expenses");
            Console.WriteLine("4. Search Expenses");
            Console.WriteLine("0. Exit");
            Console.Write("Please enter your choice: ");
        }
    }
}
