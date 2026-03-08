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
    /// Interação lógica para ErrorPopup.xam
    /// </summary>
    public partial class ErrorPopup : Window
    {
        public ErrorPopup(string mensagem)
        {
            InitializeComponent();
            TxtMessage.Text = mensagem;
        }

        // Evento para o botão fechar o popup
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
    }

