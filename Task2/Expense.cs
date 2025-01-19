using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp.Task2
{
    public abstract class Expense
    {
        List<double> RentAmount = new List<double>();   //(Tutorialsteacher, 2020) provided information on how to create and use lists
        List<double> Expenses = new List<double>();     //(Tutorialsteacher, 2020) provided information on how to create and use lists

        double FinalRentFinal;  //variable for rent deductions
        double FinalHomeFinal;  //variable for rent deductions
        double RentDeductions;  //variable for rent deductions
        double VehicleDeductions;   //variable for vehicle deductions
        double HomeDeductions;      //variable for home deductions
        double FinalRent;       //variable for final deductions
        double FinalHomeLoan;

        public List<double> GetRentAmount()
        {
            return RentAmount;      //returns the list
        }

        public List<double> GetExpenses()
        {
            return Expenses;        //returns the list
        }


        /*(Codeasy.net, 2021) provided insight on setter and getter methods, setter and getter methods
         * are made so values that are in the setter methods are returned to the getter methods, and 
         * getter methods return the values from the setter method. Getter methods are not void methods.
         */
        public void setRent(double r)       //set method for rent
        {
            RentAmount.Add(r);

        }

        public double getRent()     //get method for rent
        {
            return this.RentAmount[0];
        }

        public void setPrice(double input)      //set method for the purchase price of property
        {
            Console.WriteLine("Please insert Purchase price of property.");
            Expenses.Add(input);
        }

        public double getPrice()        //get method for the purchase price of property
        {
            return this.Expenses[0];
        }

        public void setDeposit(double input)        //set method for deposit on the property being bought
        {
            Console.WriteLine("Please insert Total deposit.");
            Expenses.Add(input);
        }

        public double getDeposit()      //get method for deposit on the property being bought
        {
            return this.Expenses[1];
        }

        public void setRate(double input)       //set method for the interst rate
        {
            Console.WriteLine("Please insert Interest rate (In percentage).");
            Expenses.Add(input);
        }

        public double getRate()     //get method for the interst rate
        {
            return this.Expenses[2];
        }


        public void setMonth(double input)      //set method for the number of months that the house being bought will be paid of
        {
            Console.WriteLine("Please insert how many Months do you want to pay for (between 240 and 360)? ");
            Expenses.Add(input);
            Console.WriteLine("");
        }

        public double getMonth()        //get method for the number of months that the house being bought will be paid of
        {
            return this.Expenses[3];
        }

        /*Two abstract methods are made so it can be inherted to the LoanCalculations. 
         * All classes and methods within the classes can be connected to each other when calculating.
         * (GeeksforGeeks, 2019) provided more insight on how to create abstract methods.
         */
        public abstract void HomeLoan(Values V, Expense LC, VehicleCalculations VC, SavingsCalculations S);


        public abstract void Rent(Values V, Expense LC);



        public void setRentDeductions(double RentDeductions)        //setter method to store rent deductions in the Loan Calculation
        {
            this.RentDeductions = RentDeductions;
            BudgetPlanning.gRentDeductions = RentDeductions;
        }

        public double getRentDeductions()   //getter method to call rent deductions in delgate method
        {
            return this.RentDeductions;
        }

        public void setVehicleDeductions(double VehicleDeductions)      //setter method to store vehicle calculation in the Loan Calculation
        {
            this.VehicleDeductions = VehicleDeductions;
        }

        public double getVehicleDeductions()        //getter method to call vehicle calculation in delgate method
        {
            return this.VehicleDeductions;
        }

        public void setHomeDeductions(double HomeDeductions)        //setter method to store home deductions in the Loan Calculation
        {
            this.HomeDeductions = HomeDeductions;
        }

        public double getHomeDeductions()       //getter method to call home deductions in the delgate 
        {
            return this.HomeDeductions;
        }

        public void setFinalRent(double FinalRent)      //setter method to store TTRS in the Loan Calculation
        {
            this.FinalRent = FinalRent;
        }

        public double getFinalRent()        //getter methods calls the TTRS to the budgetPlanning class
        {
            return this.FinalRent;
        }

        public void setFinalHomeLoan(double FinalHomeLoan)      //setter method to store TTHS in the Loan Calculation
        {
            this.FinalHomeLoan = FinalHomeLoan;
        }

        public double getFinalHomeLoan()        //getter methods calls the TTHS to the budgetPlanning class
        {
            return this.FinalHomeLoan;
        }

        public void setFinalRentFinal(double FinalRentFinal)      //setter method to store TTHS in the Loan Calculation
        {
            this.FinalRentFinal = FinalRentFinal;
        }

        public double getFinalRentFinal()        //getter methods calls the TTHS to the budgetPlanning class
        {
            return this.FinalRentFinal;
        }

        public void setFinalHomeFinal(double FinalHomeFinal)      //setter method to store TTHS in the Loan Calculation
        {
            this.FinalHomeFinal = FinalHomeFinal;
        }

        public double getFinalHomeFinal()        //getter methods calls the TTHS to the budgetPlanning class
        {
            return this.FinalHomeFinal;
        }
    }
}
