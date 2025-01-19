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
    /// Interaction logic for Rent.xaml
    /// </summary>
    public partial class Rent : Window
    {
        Boolean error;

        public Rent()
        {
            InitializeComponent();
        }

        //button to direct you to the next page
        private void next_Click(object sender, RoutedEventArgs e)
        {
            Vehicle V = new Vehicle();      //object
            Savings S = new Savings();
            
            //
            RentData.setData(ErrorCheck(rentamount.Text));
            if (!error)
            {
                BudgetPlanningData.setChoice(true); //if user chooses rent (true) then everything in this if statement can exceute

                //if statemnt to for the two different options in the combo box, user can choose the vehicle page, savings page, or expense page
                if (ComboBox.SelectedItem.Equals(veh))      //veh, sav or expenses
                {
                    this.Close();
                    V.Show();
                }

                else if (ComboBox.SelectedItem.Equals(sav))
                {
                    this.Close();
                    S.Show();
                }

                //else expense page
                else
                {
                    //get the expense inputs that were stored in the set method in the inputExpense xaml class and it is being put into the budge method
                    BudgetPlanning.Budget(InputExpensesData.getExpenseListData());  

                    //the rent option from the budget planning class is being called
                    BudgetPlanning.rentChoice(RentData.getData(), VehicleData.getVehObj(), SavingData.getSavObj());
                    ExpenseList EL = new ExpenseList();     //object

                    this.Close();
                    EL.Show();
                }

            }

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
