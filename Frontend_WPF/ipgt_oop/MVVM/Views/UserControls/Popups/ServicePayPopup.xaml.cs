using ipgt_oop.MVVM.ViewModels.UserControls.Popups;
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
using System.Windows.Shapes;

namespace ipgt_oop.MVVM.Views.UserControls.Popups
{
    /// <summary>
    /// Lógica interna para ServicePayPopup.xaml
    /// </summary>
    public partial class ServicePayPopup : Window
    {
        public ServicePayPopup()
        {
            InitializeComponent();


            this.DataContextChanged += ServicePayPopup_DataContextChanged;



        }

        private void ServicePayPopup_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
            if (e.NewValue is ServicePayPopupViewModel vm)
            {
                
                //vm.RequestErrorPopup += ShowErrorMyPopup;
                //vm.RequestSuccessPopup += ShowSucessMyPopup;
            }
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
        
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
