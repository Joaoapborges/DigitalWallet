using ipgt_oop.Core;
using ipgt_oop.MVVM.ViewModels.UserControls.Login;
using ipgt_oop.MVVM.Views.UserControls.Popups;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using YourApp.Helpers;

namespace ipgt_oop.MVVM.Views.UserControls.Login
{
    /// <summary>
    /// Interaction logic for ManualEntryForm.xaml
    /// </summary>
    public partial class ManualEntryForm : UserControl
    {
        public event EventHandler RequestHomeWindow;
        private HomeWindow _HomeWindow;

        public ManualEntryForm()
        {
            InitializeComponent();
            var vm = new ManualEntryFormViewModel();
            DataContext = vm;

            //vm.RequestHomeWindow += OpenHomeWindow;

            // NOVA LÓGIC Ligar o evento do Popup
            //vm.RequestErrorPopup += ShowMyErrorPopup;
            //vm.RequestSuccessPopup += ShowMySucessPopup; // commented because ManualEntryFormViewModel does not define this event

        }

        private void ShowMyErrorPopup(object sender, string mensagemErro)
        {
            
            var popup = new ErrorPopup(mensagemErro);

            popup.ShowDialog();
        }

        private void ShowMySucessPopup(object sender, string mensagemErro)
        {

            var popup = new SucessPopup(mensagemErro);

            popup.ShowDialog();
        }


        private void OpenHomeWindow(object sender, EventArgs e)
        {
            if (_HomeWindow == null)
            {
                _HomeWindow = new HomeWindow();
                _HomeWindow.Closed += (s, e) => _HomeWindow = null;
                _HomeWindow.Show();

                CloseWindow();
            }
            else
            {
                if (_HomeWindow.WindowState == WindowState.Minimized)
                    _HomeWindow.WindowState = WindowState.Normal;

                _HomeWindow.Activate();
                CloseWindow();
            }
        }

        private void CloseWindow()
        {
            Window parentWindow = Window.GetWindow(this);
            parentWindow?.Close();
        }

        // function to change the password visibility
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
