using ExpenseController.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace ExpenseController.UI.ViewData
{
    public class ExpenseViewData
    {
        public Expense Wrapped { get; private set; }

        private const string CurrencySymbol = "$";

        public string Date { get { return string.Format("{0:d}", Wrapped.Date); } }
        public string Description { get { return Wrapped.Description; } }
        public string Value { get { return string.Format("{0:c2}", Wrapped.Value); } }
        public string Category { get { return Wrapped.Category.Name; } }

        public ExpenseViewData(Expense expense)
        {
            Wrapped = expense;
        }

        public override string ToString()
        {
            return string.Format("{0:d} {1:c2} {2}", Date, Value, Description);
        }
    }
}
