using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseController.UI.ViewData
{
    public class CategoryExpenseViewData
    {
        public string Name { get; private set; }
        public string Value { get; private set; }

        public CategoryExpenseViewData(string name, decimal value)
        {
            Name = name;
            Value = value.ToString();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1:c2})", Name, Value);
        }
    }
}
