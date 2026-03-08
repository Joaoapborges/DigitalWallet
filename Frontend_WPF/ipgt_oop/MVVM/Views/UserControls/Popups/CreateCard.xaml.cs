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

namespace ipgt_oop.MVVM.Views.UserControls.Popups
{
    /// <summary>
    /// Lógica interna para CreateCard.xaml
    /// </summary>
    public partial class CreateCard : Window
    {
        public CreateCard()
        {
            InitializeComponent();
            DataContext = new CreateCardViewModel();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
