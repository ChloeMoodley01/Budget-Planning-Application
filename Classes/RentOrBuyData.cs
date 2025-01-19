using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Classes
{
    class RentOrBuyData
    {
        public static string RentOrBuyValue;

        public static void setRentOrBuyData(string choice)
        {
            RentOrBuyValue = choice;
        }

        public static string getRentOrBuyData()
        {
            return RentOrBuyValue;
        }
    }
}
