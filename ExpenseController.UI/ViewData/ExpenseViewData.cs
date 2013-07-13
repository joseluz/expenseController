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

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private double _value;
        public double Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
