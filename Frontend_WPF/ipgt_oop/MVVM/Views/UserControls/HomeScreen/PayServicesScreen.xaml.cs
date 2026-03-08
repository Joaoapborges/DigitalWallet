using ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen;
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
    /// Interação lógica para PayServicesScreen.xam
    /// </summary>
    public partial class PayServicesScreen : UserControl
    {
        public PayServicesScreen()
        {
            InitializeComponent();
            DataContext = new PayServicesScreenViewModel();
        }



    }
}
