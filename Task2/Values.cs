using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Task2
{
    public class Values
    {
        List<double> Income = new List<double>();   //(Tutorialsteacher, 2020) provided information on how to create and use lists
        List<double> Tax = new List<double>();      //(Tutorialsteacher, 2020) provided information on how to create and use lists
        List<double> Expenditures = new List<double>(); //(Tutorialsteacher, 2020) provided information on how to create and use lists
        public List<double> GetTax()
        {
            return Tax;     //returns the list of tax values 
        }

        public List<double> GetExpenditures()
        {
            return Expenditures;        //returns the list of all the expenditures 
        }

        public void setGMI(double ExpenseValue)        //set method for gross monthly income
        {
            Income.Add(ExpenseValue);    //user can input their value on keyboard
            Console.WriteLine("");
        }

        public double getGMI()      //get method for gross monthly income
        {
            return this.Income[0];
        }

        public void setTax(double ExpenseValue)        ////set method for tax
        {
            Tax.Add(ExpenseValue);      //user can input their value on keyboard
            Console.WriteLine("");
        }

        public double getTax()      //get method for tax
        {
            return this.Tax[0];
        }

        public void setGroceries(double ExpenseValue)      //set method for groceries 
        {
            Expenditures.Add(ExpenseValue); //expenditure list position 0 is assigned groceries and user can input their value on keyboard
            Console.WriteLine("");

        }

        public double getGroceries()        //get method for groceries 
        {
            return this.Expenditures[0];
        }

        public void setWater(double ExpenseValue)     //set method for water
        {
            Expenditures.Add(ExpenseValue);     //expenditure list position 1 is assigned water and user can input their value on keyboard
            Console.WriteLine("");
        }

        public double getWater()        //get method for water
        {
            return this.Expenditures[1];
        }

        public void setLight(double ExpenseValue)      //set method for light
        {
            Expenditures.Add(ExpenseValue);           //expenditure list position 2 is assigned light and user can input their value on keyboard
            Console.WriteLine("");
        }

        public double getLight()        //get method for light
        {
            return this.Expenditures[2];
        }

        public void setTravel(double ExpenseValue)         //set method for travel cost
        {
            Expenditures.Add(ExpenseValue);     //expenditure list position 3 is assigned travel cost and user can input their value on keyboard
            Console.WriteLine("");
        }

        public double getTravel()       //get method for travel cost
        {
            return this.Expenditures[3];
        }

        public void setCellphone(double ExpenseValue)      //set method for cellphone
        {
            Expenditures.Add(ExpenseValue);       //expenditure list position 4 is assigned cellphone and user can input their value on keyboard
            Console.WriteLine("");
        }

        public double getCellphone()        //get method for cellphone
        {
            return this.Expenditures[4];
        }

        public void setTellphone(double ExpenseValue)      //set method for tellphone
        {
            Expenditures.Add(ExpenseValue);       //expenditure list position 5 is assigned tellphone and user can input their value on keyboard
            Console.WriteLine("");
        }

        public double getTellphone()
        {
            return this.Expenditures[5];
        }

        public void setOther(double ExpenseValue)      //set method for other
        {
            Expenditures.Add(ExpenseValue);        //expenditure list position 6 is assigned other expense and user can input their value on keyboard
            Console.WriteLine("");
        }

        public double getOther()        //get method for other
        {
            return this.Expenditures[6];
        }

    }
}
