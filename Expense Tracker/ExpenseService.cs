using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class ExpenseService : IExpenseService
    {
        static List<Expense> expenses = new List<Expense>();
        public void AddExpense()
        {
            var expenseDto = GetInput();
            Expense expense = new Expense(expenseDto);
            expenses.Add(expense);
            Console.WriteLine("Expense added successfully!");
            Console.ReadLine();
        }
        public void ViewExpenses()
        {
            foreach (var expense in expenses)
            {
                Console.WriteLine($"Amount: {expense.Amount:C}, Category: {expense.Category}, Note: {expense.Note} Date: {expense.Date}");
            }
            Console.ReadLine();
        }
        public void GetSummary()
        {
            decimal totalAmount = expenses.Sum(e => e.Amount);
            Console.WriteLine($"Total expenses: {totalAmount:C}");
            Console.ReadLine();
        }
        public void SaveToFile()
        {
            Console.WriteLine("Saving expenses to file...");
            Console.ReadLine();
        }
        public void LoadFromFile()
        {
            Console.WriteLine("Loading expenses from file...");
            Console.ReadLine();
        }
        public void SearchExpenses()
        {
            List<Expense> _expense = new List<Expense>();
            Console.Write("Search by Category(1) or Date(2): ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Helpers.PrintCategories();
                    Category category = (Category)Helpers.EnumSelector("Pick an option from", 1, 8);
                     _expense = GetByCategory(category);
                    break;
                case "2":
                    Console.Write("Enter Date: ");
                    DateTime.TryParse(Console.ReadLine(), out DateTime date);
                    _expense = GetByDate(date);
                    break;
                default:
                    Console.WriteLine("Invalid Input!");
                    break;
            }
            if(_expense.Count > 0)
            {
                foreach (var expense in _expense)
                {
                    Console.WriteLine($"Amount: {expense.Amount:C}, Category: {expense.Category}, Note: {expense.Note} Date: {expense.Date}");
                }
            }
            else { Console.WriteLine("No expense found!"); }

            Console.ReadLine();
        }
        public static ExpenseDto GetInput()
        {
            Console.WriteLine("Enter the amount of the expense:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Helpers.PrintCategories();
            Category category = (Category)Helpers.EnumSelector("Pick an option from", 1, 8);
            Console.WriteLine("Enter a note for the expense:");
            string? note = Console.ReadLine();
            ExpenseDto expenseDto = new ExpenseDto
            {
                Amount = amount,
                Category = category,
                Note = note
            };
            return expenseDto;
        }
        public static List<Expense> GetByCategory(Category category)
        {
            return expenses.FindAll(cat => cat.Category.Equals(category)).ToList();
        }
        public static List<Expense> GetByDate(DateTime date)
        {
            return expenses.FindAll(d => d.Date.Equals(date)).ToList();
        }
    }
}
