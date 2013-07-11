using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseController.UI.Model
{
    public class Expense
    {
        public long Id { get; set; }

        public string Description { get; set; }
        public decimal Value { get; set; }
        public DateTime Date { get; set; }
        public ExpenseCategory Category { get; set; }
    }
}
