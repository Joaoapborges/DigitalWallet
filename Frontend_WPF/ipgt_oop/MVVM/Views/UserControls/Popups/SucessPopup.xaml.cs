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

namespace ipgt_oop.MVVM.Views.UserControls.Popups
{
    /// <summary>
    /// Interação lógica para SucessPopup.xam
    /// </summary>
    public partial class SucessPopup : Window
    {
        public SucessPopup(string mensagem)
        {
            InitializeComponent();
            TxtSuccessMessage.Text = mensagem;
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
