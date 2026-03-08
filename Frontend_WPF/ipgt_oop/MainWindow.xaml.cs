using ipgt_oop.MVVM.ViewModels;
using ipgt_oop.MVVM.ViewModels.UserControls.General;
using ipgt_oop.MVVM.ViewModels.UserControls.Login;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ipgt_oop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();

            if (TitleBar.DataContext is TitleBarViewModel vm)
            {
                vm.CloseRequested += (_, _) => Close();
            }
        }
    }
}