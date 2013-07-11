using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseController.UI.DAO
{
    public interface IDAO<T>
    {
        IEnumerable<T> List();
        void Save(T entry);
        void Delete(T entry);
        void Delete(IEnumerable<T> entries);
    }
}
