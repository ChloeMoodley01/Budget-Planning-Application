using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Task2
{
    public class SavingsCalculations
    {
        List<double> Saving = new List<double>();     //(Tutorialsteacher, 2020) provided information on how to create and use lists
        List<double> TotalSavingCost = new List<double>();  //(Tutorialsteacher.com, 2020) provided information on how to create and use lists
        double SavFinal = 0;     //made this vairable outside the method so it can be called in the Loan Calculation class
        public double sav = 0;

        public List<double> GetSavingsExpensesList()     //returns the list of all the VehicleExpensesList
        {
            return TotalSavingCost;
        }

        public void setGoal(double goal)      //set method for the purchase price of property
        {
            Saving.Add(goal);
        }

        public double getGoal()        //get method for the purchase price of property
        {
            return this.Saving[0];
        }


        public void setAmountSaved(double amount)       //set method for the interst rate
        {
            Saving.Add(amount);
        }

        public double getAmountSaved()     //get method for the interst rate
        {
            return this.Saving[1];
        }

        public void setSavRate(double rate)        //set method for deposit on the property being bought
        {
            Saving.Add(rate);
        }

        public double getSavRate()      //get method for deposit on the property being bought
        {
            return this.Saving[2];
        }


        public void setSavMonth(double year)      //set method for the number of months that the house being bought will be paid of
        {
            Saving.Add(year);

        }

        public double getSavMonth()        //get method for the number of months that the house being bought will be paid of
        {
            return this.Saving[3];
        }


        public List<double> GetTotalSavingCost()
        {
            return TotalSavingCost;     //return the Vehicle loan calculation
        }

        //(Wealth Meta, 2021) provided the saving calculations
        public void setSavingCalc()        //set method for vehicle calculation
        {
            double interest = getSavRate() / 100;       //interest (5/100)

            double savRate = interest / 12;          //0.05/12
            double savMonth = getSavMonth() * 12;       //5*12

            double sav1 = 1 + savRate;      //1 + 0.004
            double sav2 = Math.Pow(sav1, savMonth);     //1.28
            double sav3 = getAmountSaved() * sav2;      //0*0
            double sav4 = getGoal() - sav3;     //100000-0

            double sav5 = sav4 * savRate;

            double sav6 = sav2 - 1;     //1488

            SavFinal = sav5 / sav6;
            TotalSavingCost.Add(SavFinal);
        }

        public double getSavingCalc()     //get method for vehicle calculation
        {
            return TotalSavingCost[0];
        }


    }
}
