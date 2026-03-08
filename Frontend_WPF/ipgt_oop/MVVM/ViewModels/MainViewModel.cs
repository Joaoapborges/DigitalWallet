using ipgt_oop.Core;
using ipgt_oop.MVVM.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public LoginViewModel LoginVM { get; set; }
        public RegistryViewModel RegistryVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowLoginCommand { get; }
        public ICommand ShowRegistryCommand { get; }


        public MainViewModel()
        {
            
            LoginVM = new LoginViewModel();
            RegistryVM = new RegistryViewModel();

            CurrentView = LoginVM;

            ShowLoginCommand = new RelayCommand(o => CurrentView = LoginVM, o => true);
            ShowRegistryCommand = new RelayCommand(o => CurrentView = RegistryVM, o => true);

        }

    }
}
