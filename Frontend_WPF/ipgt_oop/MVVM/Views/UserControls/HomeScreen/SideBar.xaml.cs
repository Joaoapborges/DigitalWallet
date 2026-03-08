using ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen;
using ipgt_oop.MVVM.ViewModels.UserControls.Login;
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
    /// Interaction logic for SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
            var vm = new SideBarViewModel();
            DataContext = vm;
        }
    }
}
