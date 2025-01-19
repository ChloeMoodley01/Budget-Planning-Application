using BudgetApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetApp.Task2
{
    public delegate void ExceedingAmount(double num1, double num2);     //delegate made (tutorialspoint, 2021).

    class BudgetPlanning
    {

        /* object created to call methods from the LoanCalculations class and 
         * because the Expense class is connected to the LoanCalculations class, 
         * then methods from the Expense class can also be called.
         * */
        public static VehicleCalculations VC = new VehicleCalculations();     //object made to call methods and lists from the VehiclesCalculation Class
        public static ExceedingAmount EA = new ExceedingAmount(OverallExpenses);      //object made for the delegate
        public static LoanCalculations LC = new LoanCalculations();
        public static Values V = new Values();  //object created to call methods from the Values class
        public static SavingsCalculations S = new SavingsCalculations();
        public static string option = "";   //object made static so it can be called by the method overall expenses
        public static double TTRS;
        public static double TTHS;
        public static double gRentDeductions;
        public static string output = "";

        public static void Budget(double[] expense)
        {

            //all setter methods from the from the Values class are called, so the user can put in the values into the program
            Console.WriteLine("Good day. Dear User please insert the following values into the program.");
            Console.WriteLine("");
            V.setGMI(expense[0]);
            V.setTax(expense[1]);
            V.setGroceries(expense[2]);
            V.setWater(expense[3]);
            V.setLight(expense[4]);
            V.setTravel(expense[5]);
            V.setCellphone(expense[6]);
            V.setTellphone(expense[7]);
            V.setOther(expense[8]);


        }

        public static void choiceVeh (double[] callveh, string vehname) 
        {
            double rentTotalSalary = V.getGMI() - gRentDeductions;       //This is the total avaialble monthly costs
            Console.WriteLine("\nYour Final Salary with Deductions is R" + Math.Round(rentTotalSalary, 2));   //this is displaying the total avaialble monthly costs
            Console.WriteLine("");

            Console.WriteLine("Please press '1' if you have choosen to buy a car. If not, please press anything else to get your expense list.");

            string option = Console.ReadLine();     //input value if user wants to but a car
            Console.WriteLine("");

            VC.setMake(vehname);       //set method called to insert make of vehicle
            VC.setVehPrice(callveh[0]);   //set method called to insert price of vehicle
            VC.setVehDeposit(callveh[1]);  //set method called to insert deposit of vehicle
            VC.setVehInterest(callveh[2]);  //set method called to insert interest of vehicle
            VC.setVehInsurance(callveh[3]);   //set method called to insert the insurance for vehicle

            VC.buy = 1;
            
            VC.setVehCalc();        //method to calculate the vehicle loan is called
            LC.setVehicleDeductions(VC.getVehCalc());       //the set method is called from the Expenses class to contain the get method for the vehicle calcualtion so it can be called in the BudgetPlanning class 
            VehicleData.setVehObj(VC);

            TTRS = rentTotalSalary - VC.getVehCalc();
            LC.setFinalRent(TTRS);      //the set method is called from the Expenses class to contain the TTRS variable so it can be called in the BudgetPlanning class 

            EA(LC.getRentDeductions(), LC.getVehicleDeductions());      //delgate overall method is called

        }

        public static void savChoice (double [] callSav)
        {
                S.setGoal(callSav[0]);
                S.setAmountSaved(callSav[1]);
                S.setSavRate(callSav[2]);
                S.setSavMonth(callSav[3]);

                S.setSavingCalc();

                S.sav = 1;
                SavingData.setSavObj(S);

                double savFinalRentCalc = TTRS - S.getSavingCalc();
                LC.setFinalRentFinal(savFinalRentCalc);

        }

        public static void rentChoice(double r, VehicleCalculations VT, SavingsCalculations ST)
        {
                LC.setRent(r);   //user inserts their rent
                LC.Rent(V, LC);     //rent method is called
                LC.descRent(V, VT, LC, ST);     //method to put list in descending order for rent is called
        }

        public static void buyChoice(double[] inputs, VehicleCalculations VT, SavingsCalculations ST)
        {
                LC.setPrice(inputs[0]);      //user inputs price
                LC.setDeposit(inputs[1]);    //user inputs deposit
                LC.setRate(inputs[2]);      //user inputs rate
                LC.setMonth(inputs[3]);      //user inputs month

            EA(LC.getHomeDeductions(), LC.getVehicleDeductions());  //delgate method overall is called
            LC.HomeLoan(V, LC, VT, ST);     //home loan method is called
                Console.WriteLine(" \nThe Expenses in descending order value:");
                LC.descBuy(V, VT, ST);      //method to put list in descending order for homeloan is called
        }

        public static void OverallExpenses(double num1, double num2)    //delgate method overall, (tutorialspoint, 2021) helped provide this information
        {
            double income = V.getGMI();
            if (num1 + num2 > (income * 0.75))      //if above 75% then this message will display, num one and two will be added (rent & vehicle loan)
            {
                MessageBox.Show("Sorry to inform you that your Total Expenses Exceed 75% of your Income.");

            }

            //else 
            else
            {
                if (LC.buy == 1)
                {
                    if (option.Equals("Rent"))
                    {
                        Console.WriteLine("The final salary with Car deductions included is: R" + Math.Round(LC.getFinalRent(), 2));
                    }

                    else
                    {
                        Console.WriteLine("The final salary with Car deductions included is: R" + Math.Round(LC.getFinalHomeLoan(), 2));
                    }
                }

                if (LC.sav == 1)
                {
                    if (option.Equals("Rent"))
                    {
                        Console.WriteLine("The final salary with savings deductions included is: R" + Math.Round(LC.getFinalRentFinal(), 2));
                    }

                    else
                    {
                        Console.WriteLine("The final salary with savings deductions included is: R" + Math.Round(LC.getFinalHomeFinal(), 2));
                    }
                }

                //if rent and user chose 1 to buy a car, then it will display their final salary (total available monthly cost)
                //if buy and user chose 1 to buy a car, then it will display their final salary(total available monthly cost)
            }
        }


    }
}
