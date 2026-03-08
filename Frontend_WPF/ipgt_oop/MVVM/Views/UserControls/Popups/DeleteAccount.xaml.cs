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
using ipgt_oop.MVVM.ViewModels.UserControls.Popups;
using YourApp.Helpers;

namespace ipgt_oop.MVVM.Views.UserControls.Popups
{
    /// <summary>
    /// Lógica interna para DeleteAccount.xaml
    /// </summary>
    public partial class DeleteAccount : Window
    {
        private MainWindow _mainWindow;
        
        public DeleteAccount()
        {
            InitializeComponent();
            
            var vm  = new DeleteAccountViewModel();
            DataContext = vm;
            
            //vm.RequestErrorPopup += ShowErrorMyPopup;
            //vm.RequestSuccessPopup += ShowSucessMyPopup; // commented because DeleteAccountViewModel does not define this event
            //vm.RequestHomeWindow += OpenMainWindow;
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

            if (this.DataContext is DeleteAccountViewModel vm)
            {
                //vm.Password = PasswordBox.Password;
            }
        }
        
        private void ConfPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            if (this.DataContext is DeleteAccountViewModel vm)
            {
                //vm.ConfPassword = ConfPasswordBox.Password; // commented because DeleteAccountViewModel does not define ConfPassword
            }
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
                ConfPasswordBox,
                ConfPasswordTextBox,
                ConfPasswordButtonImage,
                (ImageSource)FindResource("PasswordEye"),
                (ImageSource)FindResource("PasswordEyeCrossed"));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void OpenMainWindow(object sender, EventArgs e)
        {
            if (_mainWindow == null)
            {
                _mainWindow = new MainWindow();
                _mainWindow.Closed += (s, e) => _mainWindow = null;
                _mainWindow.Show();

                CloseWindow();
                CloseHomeWindow();
            }
            else
            {
                if (_mainWindow.WindowState == WindowState.Minimized)
                    _mainWindow.WindowState = WindowState.Normal;

                _mainWindow.Activate();
                CloseWindow();   
                CloseHomeWindow();
                
            }
        }
        private void CloseWindow()
        {
            
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }
        
        private void CloseHomeWindow()
        {
            var homeWindow = System.Windows.Application.Current.Windows
                .OfType<HomeWindow>() 
                .FirstOrDefault();

            homeWindow?.Close();
        }
    }
}
