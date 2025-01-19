using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Classes
{
    class BuyData
    {
        public static double[] BuyDataV = new double[4];

        public static void setBuyData(double[] BuyV)
        {
            BuyDataV = BuyV;
        }

        public static double[] getBuyData()
        {
            return BuyDataV;
        }

        public static string buyFinal;

        public static void setBuyFinal(string fi)
        {
            buyFinal = fi;
        }

        public static string getBuyFinal()
        {
            return buyFinal;
        }
    }
}
