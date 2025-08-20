using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker.Services
{
    public interface IExpenseService
    {
        void AddExpense();

        void ViewExpenses();

        void GetSummary();

        void SaveToFile(Expense expense);
         List<Expense> LoadFromFile();

        void SearchExpenses();
    }
}
