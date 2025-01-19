using BudgetApp.Classes;
using BudgetApp.Task2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ExpenseList.xaml
    /// </summary>
    public partial class ExpenseList : Window
    {
        public static string option = "";   //object made static so it can be called by the method overall expenses

        public ExpenseList()
        {
            InitializeComponent();
            final.Text = BudgetPlanningData.getData();

        }
            
    }
}

