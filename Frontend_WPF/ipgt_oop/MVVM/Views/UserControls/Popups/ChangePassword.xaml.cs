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
using ipgt_oop.MVVM.ViewModels.UserControls.Login;
using ipgt_oop.MVVM.ViewModels.UserControls.Popups;
using YourApp.Helpers;

namespace ipgt_oop.MVVM.Views.UserControls.Popups
{
    /// <summary>
    /// Lógica interna para ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Window
    {
        public ChangePassword()
        {
            InitializeComponent();
            var vm  = new ChangePasswordViewModel();
            DataContext = vm;
            
            //vm.RequestErrorPopup += ShowErrorMyPopup;
            //vm.RequestSuccessPopup += ShowSucessMyPopup; // commented because ChangePasswordViewModel does not define this event
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

        private void ToggleConfPassword_Click(object sender, RoutedEventArgs e)
        {
            PasswordHelper.TogglePasswordVisibility(
                NewPasswordBox,
                NewPasswordTextBox,
                NewPasswordButtonImage,
                (ImageSource)FindResource("PasswordEye"),
                (ImageSource)FindResource("PasswordEyeCrossed"));
        }
        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Simplesmente fecha esta janela popup
        }
        
        private void ShowErrorMyPopup(object sender, string mensagemErro)
        {
            var popup = new ErrorPopup(mensagemErro);

            popup.ShowDialog();
        }

        private void ShowSucessMyPopup(object sender, string mensagemErro)
        {
            var popup = new SucessPopup(mensagemErro);

            popup.ShowDialog();
        }
        
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (this.DataContext is ChangePasswordViewModel vm)
            {
                //vm.Password = PasswordBox.Password;
            }
        }
        
        private void NewPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (this.DataContext is ChangePasswordViewModel vm)
            {
                //vm.NewPassword = NewPasswordBox.Password; // commented because ChangePasswordViewModel does not define NewPassword
            }
        }
    }
}
