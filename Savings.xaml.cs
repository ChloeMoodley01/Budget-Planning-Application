using BudgetApp.Classes;
using BudgetApp.Task2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BudgetApp
{
    /// <summary>
    /// Interaction logic for Savings.xaml
    /// </summary>
    public partial class Savings : Window
    {
        Boolean error;

        public Savings()
        {
            InitializeComponent();
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            //there is an array to store all the values the user inserts into the program (Troelsen and Japikse, 2017)
            double[] savArray = new double[4];

            savArray[0] = ErrorCheck(goal.Text);
            savArray[1] = ErrorCheck(savAmount.Text);
            savArray[2] = ErrorCheck(savInterest.Text);
            savArray[3] = ErrorCheck(SavMonths.Text);

            //error handling, if there isn't an error this code will excute as normal
            if (!error)
            {
                //get the expense inputs that were stored in the set method in the inputExpense xaml class and it is being put into the budge method
                BudgetPlanning.Budget(InputExpensesData.getExpenseListData());

                if (VehicleData.car)
                {
                    //the vehicle option from the budget planning class is being called
                    BudgetPlanning.choiceVeh(VehicleData.getVehData(), VehicleData.getVehMake());
                }


                SavingData.setSavData(savArray);       //method that stores double values

                if (BudgetPlanningData.choice)
                {
                    //the save option from the budget planning class is being called
                    BudgetPlanning.savChoice(SavingData.getSavData());

                    //the save option from the budget planning class is being called
                    BudgetPlanning.rentChoice(RentData.getData(), VehicleData.getVehObj(), SavingData.getSavObj());
                }

                else
                {
                    //the save option from the budget planning class is being called
                    BudgetPlanning.savChoice(SavingData.getSavData());

                    //the save option from the budget planning class is being called
                    BudgetPlanning.buyChoice(BuyData.getBuyData(), VehicleData.getVehObj(), SavingData.getSavObj());
                }

                ExpenseList EL = new ExpenseList();
                this.Close();
                EL.Show();
            }

            //else this message 
            else
            {
                MessageBox.Show("Please Enter Vaild Numbers!");
                error = false;
            }

        }

        //error check 
        private double ErrorCheck(string checkMe)
        {
            double number = 0;

            if (!double.TryParse(checkMe, out number))
            {
                number = 0;
                error = true;
            }

            return number;
        }
    }
}
