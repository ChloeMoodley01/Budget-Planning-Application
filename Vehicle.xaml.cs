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
    /// Interaction logic for Vehicle.xaml
    /// </summary>
    public partial class Vehicle : Window
    {
        Boolean error;
        private string rentORbuy;
        private double value;
        public Boolean car = true;

        public Vehicle()
        {
            InitializeComponent();
            //rentORbuy = decide;
            //value = v;
        }


        //button to direct you to the next page (expense list)
        private void next_Click(object sender, RoutedEventArgs e)
        {
            //there is an array to store all the values the user inserts into the program (Troelsen and Japikse, 2017)
            double[] md = new double[4];

            md[0] = ErrorCheck(vehprice.Text);
            md[1] = ErrorCheck(vehdeposist.Text);
            md[2] = ErrorCheck(vehinterest.Text);
            md[3] = ErrorCheck(vehinsurance.Text);

            //error handling, if there isn't an error this code will excute as normal
            if (!error)
            {
                VehicleData.setVehData(md); //method that stores double values
                VehicleData.setVehMake(modelmake.Text);     //stores string values 

                VehicleData.setvehMade(true);       //for vehicle is choosen

                if (ComboBox.SelectedItem.Equals(yes))
                {
                    Savings S = new Savings();
                    this.Close();
                    S.Show();
                }

                else
                {
                    //if user chooses rent then this methods will dispaly
                    if (BudgetPlanningData.choice)
                    {
                        //get the expense inputs that were stored in the set method in the inputExpense xaml class and it is being put into the budge method
                        BudgetPlanning.Budget(InputExpensesData.getExpenseListData());

                        //the vehicle option from the budget planning class is being called
                        BudgetPlanning.choiceVeh(md, modelmake.Text);

                        //the rent option from the budget planning class is being called
                        BudgetPlanning.rentChoice(RentData.getData(), VehicleData.getVehObj(), SavingData.getSavObj());
                    }

                    //else the buy methods will display
                    else
                    {
                        //get the expense inputs that were stored in the set method in the inputExpense xaml class and it is being put into the budge method
                        BudgetPlanning.Budget(InputExpensesData.getExpenseListData());

                        //the vehicle option from the budget planning class is being called
                        BudgetPlanning.choiceVeh(md, modelmake.Text);

                        //the buy option from the budget planning class is being called
                        BudgetPlanning.buyChoice(BuyData.getBuyData(), VehicleData.getVehObj(), SavingData.getSavObj());
                    }

                    ExpenseList EL = new ExpenseList();
                    this.Close();
                    EL.Show();
                }
            }

            //else this message box will show
            else
            {
                MessageBox.Show("Please Enter Vaild Numbers!");
                error = false;
            }

        }

        //error handling method
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
