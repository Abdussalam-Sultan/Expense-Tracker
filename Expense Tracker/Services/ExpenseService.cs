using Expense_Tracker.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Expense_Tracker.Services
{
    public class ExpenseService : IExpenseService
    {
        private static string path = "C:\\Users\\DELL\\source\\repos\\Expense Tracker\\Expense Tracker\\expenses.json";
        public void AddExpense()
        {
            var expenseDto = GetInput();
            Expense expense = new Expense(expenseDto);
            Helpers.Success("Expense added successfully!");
            SaveToFile(expense);
            Console.WriteLine("Click anywhere to continue...");
            Console.ReadLine();
        }
        public void ViewExpenses()
        {
            foreach (var expense in LoadFromFile())
            {
                Console.WriteLine($"Amount: {expense.Amount:C}, Category: {expense.Category}, Note: {expense.Note} Date: {expense.Date}");
            }
            Console.WriteLine("Click enter to continue...");
            Console.ReadLine();
        }
        public void GetSummary()
        {
            decimal totalAmount = LoadFromFile().Sum(e => e.Amount);
            Console.WriteLine($"Total number of expenses: {LoadFromFile().Count}");
            Console.WriteLine($"Expenses by category: ");
            foreach (Category category in Enum.GetValues(typeof(Category)))
            {

                List<Expense> exp = LoadFromFile().FindAll(e => e.Category == category);
                Console.WriteLine($"{category}: Count[{exp.Count}] Amount[{exp.Sum(e => e.Amount)}]");
                Console.WriteLine("--------------------------------------");
            }
            Console.WriteLine($"Total number of expenses by date: ");

            Console.WriteLine($"Total amount spent: {totalAmount:C}");
            Console.WriteLine("Click enter to continue...");
            Console.ReadLine();
        }
        public void SaveToFile(Expense ex)
        {
            var expense = LoadFromFile();
            expense.Add(ex);
            string json = JsonSerializer.Serialize(expense, new JsonSerializerOptions { WriteIndented = true});
            File.WriteAllText(path, json);
        }
        public List<Expense> LoadFromFile()
        {
            if (!File.Exists(path))
                return new List<Expense>();
            string loadedJson = File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Expense>>(loadedJson);
        }
        public void SearchExpenses()
        {
            List<Expense> _expense = new List<Expense>();
            Console.Write("Search by Category(1) or Date(2): ");
            string? choice = Console.ReadLine();
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
            }
            if(_expense.Count > 0)
            {
                foreach (var expense in _expense)
                {
                    Console.WriteLine($"Amount: {expense.Amount:C}, Category: {expense.Category}, Note: {expense.Note} Date: {expense.Date}");
                }
            }
            else 
            { 
                Helpers.Failure("No expense found!");
                Console.WriteLine("Click enter to continue...");
            }

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
        public List<Expense> GetByCategory(Category category)
        {

            return LoadFromFile().FindAll(cat => cat.Category.Equals(category)).ToList();
        }
        public List<Expense> GetByDate(DateTime date)
        {
            return LoadFromFile().FindAll(d => d.Date.Equals(date)).ToList();
        }
    }
}
