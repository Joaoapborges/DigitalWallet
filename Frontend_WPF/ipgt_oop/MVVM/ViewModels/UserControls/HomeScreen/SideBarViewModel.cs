using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    public class SideBarViewModel : ObservableObject
    {
        private string _selected;
        public string Selected
        {
            get => _selected;
            set => SetProperty(ref _selected, value); 
        }

        public RelayCommand SelectCommand { get; }

        public SideBarViewModel()
        {
            SelectCommand = new RelayCommand(OnSelect, CanSelect);
        }

        private void OnSelect(object parameter)
        {
            if (parameter is string selection)
            {
                Selected = selection;
            }
        }

        private bool CanSelect(object parameter) => true;
    }

}
