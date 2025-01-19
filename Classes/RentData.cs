using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Classes
{
    class RentData
    {
        public static double RentDataV;

        public static void setData(double rent)
        {
            RentDataV = rent;
        }

        public static double getData()
        {
            return RentDataV;
        }
    }
}
