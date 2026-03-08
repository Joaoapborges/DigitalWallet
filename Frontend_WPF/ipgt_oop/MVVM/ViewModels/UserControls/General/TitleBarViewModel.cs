using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels.UserControls.General
{

    class TitleBarViewModel : ObservableObject
    {
        public event EventHandler? CloseRequested;
        public ICommand CloseCommand { get; }

        public TitleBarViewModel()
        {
            CloseCommand = new RelayCommand(
                _ => CloseRequest(),
                _ => true);
        }

        private void CloseRequest()
        {
            CloseRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
