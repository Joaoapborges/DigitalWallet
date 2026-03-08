using ipgt_oop.MVVM.ViewModels;
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
using ipgt_oop.MVVM.Views.UserControls.Popups;
using YourApp.Helpers;

namespace ipgt_oop.MVVM.Views
{
    /// <summary>
    /// Interaction logic for RegistryView.xaml
    /// </summary>
    public partial class RegistryView : UserControl
    {
        public RegistryView()
        {
            InitializeComponent();
            var vm =  new RegistryViewModel();
            DataContext = vm;
            
            vm.RequestErrorPopup += ShowMyErrorPopup;
            vm.RequestSuccessPopup += ShowMySucessPopup;
            
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

            // volta para a main window

            if (Application.Current.MainWindow.DataContext is MainViewModel mainVm)
            {
                mainVm.ShowLoginCommand.Execute(null);
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
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            // Verifica se o DataContext é o RegistryViewModel correto
            if (this.DataContext is RegistryViewModel vm)
            {
                // Atualiza a propriedade Password no ViewModel sempre que o utilizador digita algo
                vm.Password = PasswordBox.Password;
            }
        }
    }
}
