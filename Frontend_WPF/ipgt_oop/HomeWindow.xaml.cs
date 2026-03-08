using ipgt_oop.MVVM.ViewModels;
using ipgt_oop.MVVM.ViewModels.UserControls.General;
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

namespace ipgt_oop
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();

            if (TitleBar.DataContext is TitleBarViewModel vm)
            {
                vm.CloseRequested += (_, _) => Close();
            }
        }
    }
}
