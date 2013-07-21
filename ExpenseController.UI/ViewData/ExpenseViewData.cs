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
        private const string CurrencySymbol = "$";

        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return string.Format("{0:d} {1}{2:n2} {3}", Date, CurrencySymbol, Value, Name);
        }
    }
}
