using BudgetApp.Classes;
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
    /// Interaction logic for RentOrBuy.xaml
    /// </summary>
    public partial class RentOrBuy : Window
    {
        
        public RentOrBuy()
        {
            InitializeComponent();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            Rent r = new Rent();        //object
            Buy b = new Buy();      //object

            //if statemnt to for the two different options in the combo box, if rent then it goes to the rent page, else the buy pase
            if (ComboBox.SelectedItem.Equals(rent))
            {
                RentOrBuyData.setRentOrBuyData("rent");
                this.Close();
                r.Show();
            }

            else
            {
                RentOrBuyData.setRentOrBuyData("buy");
                this.Close();
                b.Show();
            }
        }
    }
}
