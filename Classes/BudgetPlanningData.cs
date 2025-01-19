using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Classes
{
    public class BudgetPlanningData
    {
        public static string output;
        public static Boolean choice = false;

        public static void setData(string outp)
        {
            output = outp;
        }

        public static string getData()
        {
            return output;
        }

        public static void setChoice(Boolean userChoice)
        {
            choice = userChoice;
        }
    }
}
