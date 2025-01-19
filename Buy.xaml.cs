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
    /// Interaction logic for Buy.xaml
    /// </summary>
    public partial class Buy : Window
    {
        List<double> Expenses = new List<double>();     //(Tutorialsteacher, 2020) provided information on how to create and use lists
        Boolean error;
        static Buy b = new Buy();
        double HomeDeductions;      //variable for home deductions
        double FinalHomeLoan;
        public int buy;     //this is variable is made public so it can be called by the budget planning class
        public static double monthRepayments;   //this is made is public static so it can be called by a void method (buyDesc)
        double buyValue;

        public Buy()
        {
            InitializeComponent();
        }

        //button to direct you to the next page
        private void next_Click(object sender, RoutedEventArgs e)
        {
            //there is an array to store all the values the user inserts into the program (Troelsen and Japikse, 2017)
            double[] storeV = new double[4];

            //error check is a method for error handling and the specfic positions in the array is being assigned to cetrian imput values
            storeV[0] = ErrorCheck(price.Text);
            storeV[1] = ErrorCheck(deposit.Text);
            storeV[2] = ErrorCheck(interest.Text);
            storeV[3] = ErrorCheck(months.Text);

            if (!error)
            {   
                //error handling so user cannont enter anything be under 240 and over 360
                if (storeV[3] < 240 || storeV[3] > 360)
                {
                    MessageBox.Show("Please choose the months between 240 - 360");
                }

                else
                {
                    BuyData.setBuyData(storeV);     //stores variables
                    BudgetPlanningData.setChoice(false);        //buy method will run

                    //if statemnt to for the two different options in the combo box, if yes then it goes to the vehicle page, else the expense pase
                    if (ComboBox.SelectedItem.Equals(veh))
                    {
                        Vehicle V = new Vehicle();      //object
                        this.Close();
                        V.Show();

                    }
                    else if (ComboBox.SelectedItem.Equals(sav))
                    {
                        Savings S = new Savings();
                        this.Close();
                        S.Show();
                    }

                    else
                    {
                        //get the expense inputs that were stored in the set method in the inputExpense xaml class and it is being put into the budge method
                        BudgetPlanning.Budget(InputExpensesData.getExpenseListData());

                        //the buy option from the budget planning class is being called
                        BudgetPlanning.buyChoice(BuyData.getBuyData(), VehicleData.getVehObj(), SavingData.getSavObj());
                        MessageBox.Show("get data in expense list" + BudgetPlanningData.getData());

                        ExpenseList EL = new ExpenseList();     //object
                        this.Close();
                        EL.Show();
                    }
                }
            }

            //else this message box will show
            else
            {
                MessageBox.Show("Please Enter Vaild Numbers!");
                error = false;
            }

            
        }

        private double ErrorCheck(string checkMe)
        {
            double number = 0;

            if (!double.TryParse(checkMe, out number))      //the tryparse to ensure all values are double(Microsoft, 2021)
            {
                number = 0;
                error = true;
            }

            return number;
        }

    }
}
