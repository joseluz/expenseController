using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;

namespace ExpenseController.UI.Model
{
    public class ExpenseCategory
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public Color Color { get; set; }
    }
}
