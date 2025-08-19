using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public Expense(ExpenseDto expenseDto)
        {
            Id = new Random().Next(1, 1000); // Simple ID generation for demonstration
            Amount = expenseDto.Amount;
            Category = expenseDto.Category;
            Date = DateTime.Now; // Set to current date
            Note = expenseDto.Note ?? string.Empty; // Default to empty string if null
        }

        public override string ToString()
        {
            return $"{Id,-5} {Date.ToShortDateString(),-12} {Category,-15} ₦{Amount,-10} {Note}";
        }
    }
}
