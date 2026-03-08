using ipgt_oop.MVVM.ViewModels.UserControls.Login;
using ipgt_oop.MVVM.ViewModels.UserControls.Popups;
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
using YourApp.Helpers;

namespace ipgt_oop.MVVM.Views.UserControls.Popups
{
    /// <summary>
    /// Lógica interna para DeleteCard.xaml
    /// </summary>
    public partial class DeleteCard : Window
    {
        public DeleteCard()
        {
            InitializeComponent();

            
            var vm = new DeletecardViewModel();
            this.DataContext = vm; 

            //vm.CloseAction = new Action(() => this.Close()); // commented because DeletecardViewModel does not define CloseAction
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TogglePassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordHelper.TogglePasswordVisibility(
                PasswordBox,
                PasswordTextBox,
                PasswordButtonImage,
                (ImageSource)FindResource("PasswordEye"),
                (ImageSource)FindResource("PasswordEyeCrossed"));
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (this.DataContext is ManualEntryFormViewModel vm)
            {
                //vm.Password = PasswordBox.Password;
            }
        }
    }
}