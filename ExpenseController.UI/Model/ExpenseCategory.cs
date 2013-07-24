using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ExpenseController.UI.Model
{
    public class ExpenseCategory
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public Color Color { get; set; }
        public Brush BackColor { get; set; }
        public ImageSource Image { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as ExpenseCategory;
            return other != null && other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
