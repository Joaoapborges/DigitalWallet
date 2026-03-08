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

using ipgt_oop.MVVM.Views.UserControls.Popups;
namespace ipgt_oop.MVVM.Views.UserControls.HomeScreen
{
    /// <summary>
    /// Interação lógica para SettingsScreen.xam
    /// </summary>
    public partial class SettingsScreen : UserControl
    {
        public SettingsScreen()
        {
            InitializeComponent();
            DataContext = new SettingsScreenViewModel();
        }

        private void OpenPopup_click(object sender, RoutedEventArgs e)
        {

            ChangePassword popup = new ChangePassword();


            popup.Owner = Application.Current.MainWindow;
            popup.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            popup.ShowDialog();
        }

        private void OpenPopupNewCard_click(object sender, RoutedEventArgs e)
        {

            CreateCard popup = new CreateCard();


            popup.Owner = Application.Current.MainWindow;
            popup.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            popup.ShowDialog();
        }

        private void OpenPopupDeleteAccount_click(object sender, RoutedEventArgs e)
        {

            DeleteAccount popup = new DeleteAccount();


            //popup.Owner = Application.Current.MainWindow;
            popup.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            popup.ShowDialog();
        }

        private void OpenPopupDeleteCard_click(object sender, RoutedEventArgs e)
        {

            DeleteCard popup = new DeleteCard();


            //popup.Owner = Application.Current.MainWindow;
            popup.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            popup.ShowDialog();
        }
    }

    }
    

