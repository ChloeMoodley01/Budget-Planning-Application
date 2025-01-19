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
    /// Interaction logic for InputExpenses.xaml
    /// </summary>
    public partial class InputExpenses : Window
    {
        Boolean error = false;

        public InputExpenses()
        {
            InitializeComponent();
        }

        //button to direct you to the next page (Rent/Buy)
        private void submit_Click(object sender, RoutedEventArgs e)
        {

            double[] expense = new double[9];       //there is an array to store all the values the user inserts into the program (Troelsen and Japikse, 2017)
            
            //error check is a method for error handling and the specfic positions in the array is being assigned to cetrian imput values
            expense[0] = ErrorCheck(GMI.Text);
            expense[1] = ErrorCheck(tax.Text);
            expense[2] = ErrorCheck(groc.Text);
            expense[3] = ErrorCheck(water.Text);
            expense[4] = ErrorCheck(light.Text);
            expense[5] = ErrorCheck(TC.Text);
            expense[6] = ErrorCheck(CP.Text);
            expense[7] = ErrorCheck(TP.Text);
            expense[8] = ErrorCheck(other.Text);

            //if there is not an error then code will excute as normal
            if (!error)
            {
                //set method to store expense list
                InputExpensesData.setExpenseListData(expense);

                RentOrBuy RB = new RentOrBuy();
                this.Close();
                RB.Show();
            }

            //else if there is an error then that message box will display
            else
            {
                MessageBox.Show("Please Enter Vaild Numbers!");
                error = false;
            }
        }

        private double ErrorCheck (string checkMe)
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
