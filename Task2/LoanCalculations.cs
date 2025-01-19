using BudgetApp.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetApp.Task2
{
    public class LoanCalculations : Expense    //inherits the expense class
    {
        public int sav;
        public int buy;     //this is variable is made public so it can be called by the budget planning class
        public static double monthRepayments;   //this is made is public static so it can be called by a void method (buyDesc)
        public static double TTRS;
        public static double TTHS;

        public override void Rent(Values V, Expense LC)     //the rent method is inherted to this class, and will calculate the users final salary
        {
            double rentDeductions = V.getTax() + V.getGroceries() + V.getWater() + V.getLight()
                                      + V.getTravel() + V.getCellphone() + V.getTellphone() + V.getOther()
                                      + LC.getRent();       //all the expenses and the expenditures are added together

            LC.setRentDeductions(rentDeductions);   //the set method is called from the Expenses class to contain the rent deduction variable so it can be called in the BudgetPlanning class 

            /*an if else statement is made, if the deductions are more than the salary then the user will be notified, 
             * else their final salary will be displayed.
             * */
            if (V.getGMI() < rentDeductions)
            {
                MessageBox.Show("Your deductions are higher than your salary.");
            }

            else
            {
                /* all the rent deductions (expenses and expenditures) 
                * are subtracted from the gross monthly income to calculate the final salary amount, 
                * how much the user will have left.
                * */
                double rentTotalSalary = V.getGMI() - rentDeductions;       //This is the total avaialble monthly costs
                Console.WriteLine("\nYour Final Salary with Deductions is R" + Math.Round(rentTotalSalary, 2));   //this is displaying the total avaialble monthly costs
                Console.WriteLine("");


            }


        }

        /*the homeLoan method is inherted to this class, 
         * this method will take all the values that the user inserts from the other classes and 
         * calculate the monthly payments as well as calculating the final salary of the user, 
         * and if the user can qualify for the loan
         * */

        public override void HomeLoan(Values V, Expense LC, VehicleCalculations VC, SavingsCalculations S)
        {
            //(The Balance, 2020) provided the formula used to calculate the home loan repayments

            double LoanAmount = LC.getPrice() - LC.getDeposit();   //the deposit is subtracted from the purchase price, to create the Loan amount (A) 
            double ConvertInterest = LC.getRate() / 100;           //the interest rate is divided by 100, to make the interest rate a decimal
            double AnnualRate = ConvertInterest / 12;              //the decimal interest rate is divided by 12, because we are calculating monthly (r)
            double Calc1 = 1 + AnnualRate;                         //1 is added to r
            double Calc2 = Math.Pow(Calc1, LC.getMonth());         //Calc1 to the power of getMonths(n) is calculated in this line
            double Calc3 = Calc2 - 1;                              //1 is subtracted Calc2 
            double Calc4 = Math.Pow(Calc1, LC.getMonth());         //Calc1(r+1) to the power of getMonths(n) is calculated
            double Calc5 = Calc4 * AnnualRate;                     //Calc4 is being multplied by (r) 
            double Calc6 = Calc3 / Calc5;                          //Calc3 is divided by Calc5
            monthRepayments = LoanAmount / Calc6;           //LoanAmount, the actual price of property is divided by Calc6


            Console.WriteLine("The monthly Repayments are R: " + Math.Round(monthRepayments, 2));    //displays monthly repayments
            Console.WriteLine("");

            double third = V.getGMI() / 3;      //the gross monthly income is divided by three, to determine what 1/3 of the users salary is

            if (monthRepayments > third)        //if the monthly payments for the house is more than a third of the users salary, then they will not qualify for the loan.
            {
                Console.WriteLine("Dear User, The Home Loan you requested will be unlikely due to the Monthly Repayments being more than 1/3 of your salary. " +
                    "Our deepest apologies.");
            }

            else        //else they do qualify for the loan and the user final salary (after deductions) will be displayed
            {
                Console.WriteLine("Congratulations!!! You qualify for your home loan.");
                Console.WriteLine("");

                double homeDeductions = V.getTax() + V.getGroceries() + V.getWater() + V.getLight()
                                  + V.getTravel() + V.getCellphone() + V.getTellphone() + V.getOther()
                                  + monthRepayments;        //all the expenses, expenditures and monthly repayments are added together

                LC.setHomeDeductions(homeDeductions);   //the set method is called from the Expenses class to contain the home deduction variable so it can be called in the BudgetPlanning class 

                /*home deductions (expenses, expenditures, and monthly repayments) are 
                 * subtracted from the gross monthly income, to determine the users final
                 * salary after deductions
                 * */
                double homeTotalSalary = V.getGMI() - homeDeductions;       //calculates total available salary
                Console.WriteLine("Your Final Salary with Deductions is R" + Math.Round(homeTotalSalary, 2));     //DISPLAYS TOTAL AVAILABLE MONTHLY COSTS

                Console.WriteLine("");
                Console.WriteLine("Please press '1' if you have choosen to buy a car. If not, please press anything else to get final Salary.");

                string option = Console.ReadLine();     //input value if user wants to but a car
                Console.WriteLine("");

            }

        }

        public void descRent(Values V, VehicleCalculations VC, Expense LC, SavingsCalculations S)      //objects called in the parameters so methods variables can be called from other classes
        {
            //All the lists are added to the ExpendituresValuesA
            List<double> ExpendituresValuesA = new List<double>();      //(Tutorialsteacher 2020) provided information on how to create and use lists
            ExpendituresValuesA.AddRange(V.GetTax());
            ExpendituresValuesA.AddRange(V.GetExpenditures());
            ExpendituresValuesA.AddRange(LC.GetRentAmount());

            //All the lists are added to the SortedExpendituresValuesA
            List<double> SortedExpendituresValuesA = new List<double>();        //(Tutorialsteacher.com, 2020) provided information on how to create and use lists
            SortedExpendituresValuesA.AddRange(V.GetTax());
            SortedExpendituresValuesA.AddRange(V.GetExpenditures());
            SortedExpendituresValuesA.AddRange(LC.GetRentAmount());

            //Array to store the string (Names) (Troelsen and Japikse). 
            string[] Expenditures = { "Tax", "Groceries", "Water", "Light", "Travel Cost", "Cellphone", "Tellphone", "Other Expenses", "Rent Amount" };
            List<string> Expenditure1 = new List<string>();
            Expenditure1.AddRange(Expenditures);

            if (VC.buy == 1)
            {
                ExpendituresValuesA.Add(Math.Round(VC.GetTotalCarMonthlyCost()[0], 2));
                SortedExpendituresValuesA.Add(Math.Round(VC.GetTotalCarMonthlyCost()[0], 2));
                Expenditure1.Add("The Vehicle Calculation");

            }

            if (S.sav == 1)
            {
                ExpendituresValuesA.Add(Math.Round(S.GetSavingsExpensesList()[0], 2));
                SortedExpendituresValuesA.Add(Math.Round(S.GetSavingsExpensesList()[0], 2));
                Expenditure1.Add("The Savings Calculation");

            }

            double expenses = 0;
            for (int i = 0; i < ExpendituresValuesA.Count; i++)
            {
                expenses += ExpendituresValuesA[i];
            }

            double FinalSalary = V.getGMI() - expenses;

            SortedExpendituresValuesA.Sort();       //sorted in ascending order (Troelsen and Japikse, 2017). 
            SortedExpendituresValuesA.Reverse();    //reverse the ascending order list making it descending order (Troelsen and Japikse). 

            //Array to store sorted values
            string[] SortedExpenditures = new string[200];  //(Troelsen and Japikse, 2017). 

            //Tutorialspoint, 2021 helped understand bubble sort code, so i could implement here
            for (int i = 0; i < SortedExpendituresValuesA.Count; i++)   //for loop that sorts ot all the variables
            {
                for (int k = 0; k < ExpendituresValuesA.Count; k++)     //nested for loop to sort through ExpendituresValuesA
                {
                    if (SortedExpendituresValuesA[i] == ExpendituresValuesA[k])     //if list i == value k then if both values are not found, values will start to be stored in the sorted array
                    {
                        SortedExpenditures[i] = Expenditure1[k];
                        Expenditure1.RemoveAt(k);
                        ExpendituresValuesA.RemoveAt(k);
                        break;
                    }
                }
            }

            string display = "";

            //displays the list (EDUCBA, 2019). 
            for (int i = 0; i < SortedExpendituresValuesA.Count; i++)
            {
                Debug.WriteLine(SortedExpenditures[i] + " is R:" + SortedExpendituresValuesA[i]);
                display  = display + SortedExpenditures[i] + " is R:" + SortedExpendituresValuesA[i] +"\n";

            }

            display = display + "\n" + "Total Expenses R:" + Math.Round(expenses,2) + "\n" + "The Final Salary R:" + Math.Round(FinalSalary,2);
            BudgetPlanningData.setData(display);
        }


        public void descBuy(Values V, VehicleCalculations VC, SavingsCalculations S)         //objects called in the parameters so methods variables can be called from other classes
        {
            List<double> ExpendituresValuesA = new List<double>();      //(Tutorialsteacher 2020) provided information on how to create and use lists
            ExpendituresValuesA.AddRange(V.GetTax());
            ExpendituresValuesA.AddRange(V.GetExpenditures());
            ExpendituresValuesA.Add(Math.Round(monthRepayments, 2));

            //All the lists are added to the SortedExpendituresValuesA
            List<double> SortedExpendituresValuesA = new List<double>();        //(Tutorialsteacher.com, 2020) provided information on how to create and use lists
            SortedExpendituresValuesA.AddRange(V.GetTax());
            SortedExpendituresValuesA.AddRange(V.GetExpenditures());
            SortedExpendituresValuesA.Add(Math.Round(monthRepayments, 2));

            //Array to store the string (Names) (Troelsen and Japikse). 
            string[] Expenditures = { "Tax", "Groceries", "Water", "Light", "Travel Cost", "Cellphone", "Tellphone", "Other Expenses", "Monthly Repayments" };
            List<string> Expenditure1 = new List<string>();
            Expenditure1.AddRange(Expenditures);

            if (VC.buy == 1)
            {
                ExpendituresValuesA.Add(Math.Round(VC.GetTotalCarMonthlyCost()[0], 2));
                SortedExpendituresValuesA.Add(Math.Round(VC.GetTotalCarMonthlyCost()[0], 2));
                Expenditure1.Add("The Vehicle Calculation");
                


            }

            if (S.sav == 1)
            {
                ExpendituresValuesA.Add(Math.Round(S.GetSavingsExpensesList()[0], 2));
                SortedExpendituresValuesA.Add(Math.Round(S.GetSavingsExpensesList()[0], 2));
                Expenditure1.Add("The Savings Calculation");
                

            }

            double expenses = 0;
            for (int i = 0; i < ExpendituresValuesA.Count; i++)
            {
                expenses += ExpendituresValuesA[i];
            }

            double FinalSalary = V.getGMI() - expenses;

            SortedExpendituresValuesA.Sort();       //sorted in ascending order (Troelsen and Japikse). 
            SortedExpendituresValuesA.Reverse();    //reverse the ascending order list making it descending order (Troelsen and Japikse). 

            //Array to store sorted values
            string[] SortedExpenditures = new string[11];  //(Troelsen and Japikse). 

            //Tutorialspoint, 2021 helped understand bubble sort code, so i could implement here
            for (int i = 0; i < SortedExpendituresValuesA.Count; i++)   //for loop that sorts ot all the variables
            {
                for (int k = 0; k < ExpendituresValuesA.Count; k++)     //nested for loop to sort through ExpendituresValuesA
                {
                    if (SortedExpendituresValuesA[i] == ExpendituresValuesA[k])     //if list i == value k then if both values are not found, values will start to be stored in the sorted array
                    {
                        SortedExpenditures[i] = Expenditure1[k];
                        Expenditure1.RemoveAt(k);
                        ExpendituresValuesA.RemoveAt(k);
                        break;
                    }
                }
            }

            string display = "";
            //displays the list (EDUCBA, 2019). 
            for (int i = 0; i < SortedExpendituresValuesA.Count; i++)
            {
                Debug.WriteLine(SortedExpenditures[i] + " is R:" + SortedExpendituresValuesA[i]);
                display = display + SortedExpenditures[i] + " is R:" + SortedExpendituresValuesA[i] + "\n";

            }
            display = display+ "\n" + "Total Expenses R:" +Math.Round(expenses,2) +"\n" + "The Final Salary R:" +Math.Round(FinalSalary, 2);
            
            BudgetPlanningData.setData(display);
        }

    }
}
