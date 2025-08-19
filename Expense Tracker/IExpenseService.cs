using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expense_Tracker
{
    public interface IExpenseService
    {
        void AddExpense();

        void ViewExpenses();

        void GetSummary();

        void SaveToFile();
        void LoadFromFile();

        void SearchExpenses();
    }
}
