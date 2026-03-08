using ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen;
using ipgt_oop.MVVM.ViewModels.UserControls.Popups;
using ipgt_oop.MVVM.Views.UserControls.Popups;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ipgt_oop.MVVM.Views.UserControls.HomeScreen
{
    /// <summary>
    /// Interação lógica para TransactionScreen.xam
    /// </summary>
    public partial class TransactionScreen : UserControl
    {
        public TransactionScreen()
        {
            InitializeComponent();
            DataContext = new TransactionScreenViewModel();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
