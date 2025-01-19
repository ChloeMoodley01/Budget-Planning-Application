using BudgetApp.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Classes
{
    class SavingData
    {
        public static double[] SavingDataV = new double[4];
        public static SavingsCalculations S = new SavingsCalculations();

        public static void setSavData(double[] Sav)
        {
            SavingDataV = Sav;
        }

        public static double[] getSavData()
        {
            return SavingDataV;
        }

        public static void setSavObj(SavingsCalculations ST)
        {
            S = ST;
        }

        public static SavingsCalculations getSavObj()
        {
            return S;
        }
    }
}
