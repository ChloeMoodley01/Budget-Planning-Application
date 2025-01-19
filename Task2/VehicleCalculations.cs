using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Task2
{
    public class VehicleCalculations : Vehicle
    {

        public double buy = 0;
        List<double> TotalCarMonthlyCost = new List<double>();  //(Tutorialsteacher.com, 2020) provided information on how to create and use lists
        double TotalMontlyCost = 0;     //made this vairable outside the method so it can be called in the Loan Calculation class

        public List<double> GetTotalCarMonthlyCost()
        {
            return TotalCarMonthlyCost;     //return the Vehicle loan calculation
        }

        public void setVehCalc()        //set method for vehicle calculation
        {
            //vehicle calculation formula
            double Loan = getVehPrice() - getVehDeposit();              //deposit subtracted by price to get the loan
            double numerator = (getVehInterest() / 100) / 12;       //made the interest into the decimal, then divided that by 12
            double denominator = 1 - (Math.Pow(1 + numerator, -60));    //the numerator plus square rooted -60 (5 years) 
            TotalMontlyCost = (Loan * (numerator / denominator) + getVehInsurnace());   //numerator divided by the denominator multplied by loan
            TotalCarMonthlyCost.Add(TotalMontlyCost);       //added to the list

        }

        public double getVehCalc()     //get method for vehicle calculation
        {
            return TotalCarMonthlyCost[0];
        }

    }
}
