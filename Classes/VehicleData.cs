using BudgetApp.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Classes
{
    class VehicleData
    {
        public static Boolean car;
        public static double[] VehicleDataV = new double[4];
        public static string VehicleDataT;
        public static VehicleCalculations VC = new VehicleCalculations();

        public static void setVehData(double[] VehV)
        {
            VehicleDataV = VehV;
        }

        public static double[] getVehData()
        {
            return VehicleDataV;
        }

        public static void setVehMake(string VehMake)
        {
            VehicleDataT = VehMake;
        }

        public static string getVehMake()
        {
            return VehicleDataT;
        }

        public static void setVehObj(VehicleCalculations VT)
        {
            VC = VT;
        }

        public static VehicleCalculations getVehObj()
        {
            return VC;
        }

        public static void setvehMade(Boolean vMade)
        {
            car = vMade;
        }
    }
}
