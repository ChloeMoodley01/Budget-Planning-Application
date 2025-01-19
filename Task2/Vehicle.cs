using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Task2
{
    public class Vehicle
    {

        List<String> ModelAndMakeList = new List<string>();     //(Tutorialsteacher, 2020) provided information on how to create and use lists
        List<double> VehicleExpensesList = new List<double>();  //(Tutorialsteacher 2020) provided information on how to create and use lists

        public List<double> GetVehicleExpensesList()     //returns the list of all the VehicleExpensesList
        {
            return VehicleExpensesList;
        }

        public void setModel()       //set method for model
        {
            Console.WriteLine("Please insert the Model of your vehicle.");
            ModelAndMakeList.Add(Console.ReadLine());
            Console.WriteLine("");
        }

        public string getModel()        //get method for model
        {
            return this.ModelAndMakeList[0];
        }

        public void setMake(string make)       //set method for make
        {
            ModelAndMakeList.Add(make);
            Console.WriteLine("");
        }

        public string getMake()     //get method for make
        {
            return this.ModelAndMakeList[1];
        }

        public void setVehPrice(double price)        //set method for price
        {
            VehicleExpensesList.Add(price);
            Console.WriteLine("");
        }

        public double getVehPrice()     //get method for price
        {
            return this.VehicleExpensesList[0];
        }

        public void setVehDeposit(double deposit)      //set method for deposit
        {
            VehicleExpensesList.Add(deposit);
            Console.WriteLine("");
        }

        public double getVehDeposit()       //get method for deposit
        {
            return this.VehicleExpensesList[1];
        }

        public void setVehInterest(double interest)         //set method for interst
        {
            VehicleExpensesList.Add(interest);
            Console.WriteLine("");
        }

        public double getVehInterest()      //get method for interest
        {
            return this.VehicleExpensesList[2];
        }

        public void setVehInsurance(double insurance)        //set method for vehicle insurance
        {
            VehicleExpensesList.Add(insurance);
            Console.WriteLine("");
        }

        public double getVehInsurnace()     //get method for vehicle insurance
        {
            return this.VehicleExpensesList[3];
        }

    }
}
