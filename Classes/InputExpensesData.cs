using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Classes
{
    public class InputExpensesData
    {
        public static double[] InputExpenseData = new double[9];

        public static void setExpenseListData(double[] Exp)
        {
            InputExpenseData = Exp;
        }

        public static double[] getExpenseListData ()
        {
            return InputExpenseData;
        }
    }
}
