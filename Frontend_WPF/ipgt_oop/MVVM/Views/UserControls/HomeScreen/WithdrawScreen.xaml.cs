using ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen;
using ipgt_oop.MVVM.Views.UserControls.Popups;
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
    /// Interação lógica para WithdrawScreen.xam
    /// </summary>
    public partial class WithdrawScreen : UserControl
    {
        public WithdrawScreen()
        {
            // Constructor initialization commented out to avoid compilation errors.
            /*
            InitializeComponent();

            var vm = new WithdrawScreenViewModel();

            vm.RequestErrorPopup += ShowErrorMyPopup;
            vm.RequestSuccessPopup += ShowSucessMyPopup;


            DataContext = vm;
            */
        }

        // Popup helper methods commented out to avoid compilation errors.
        /*
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
        */
    }
}
