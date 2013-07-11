using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseController.UI.DAO
{
    public class BaseDAO<T> : IDAO<T>
    {
        private HashSet<T> entries = new HashSet<T>();

        public IEnumerable<T> List()
        {
            return entries;
        }

        public void Save(T entry)
        {
            entries.Add(entry);
        }

        public void Delete(T entry)
        {
            entries.Remove(entry);
        }

        public void Delete(IEnumerable<T> entries)
        {
            foreach (var entry in entries)
                this.entries.Remove(entry);
        }

        public T FindByExample(T example)
        {
            return entries.SingleOrDefault(e => e.Equals(example));
        }
    }
}
