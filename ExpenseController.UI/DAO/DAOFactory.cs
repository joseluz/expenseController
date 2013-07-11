using ExpenseController.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseController.UI.DAO
{
    public static class DAOFactory
    {
        public static BaseDAO<Expense> ExpenseDAO { get; private set; }
        public static BaseDAO<ExpenseCategory> ExpenseCategoryDAO { get; private set; }

        static DAOFactory() 
        {
            ExpenseDAO = new BaseDAO<Expense>();
            ExpenseCategoryDAO = new BaseDAO<ExpenseCategory>();

            InitializeExpenses();
            InitializeCategories();
        }

        private static void InitializeExpenses()
        {
        }

        private static void InitializeCategories()
        {
        }
    }
}
