using ipgt_oop.Core;
using ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen;
using ipgt_oop.MVVM.Views.UserControls.HomeScreen;
using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels
{
    class HomeViewModel : ObservableObject
    {
        public SideBarViewModel SideBarViewModel { get; }
        public DashboardScreenViewModel DashboardVM { get; set; }
        public TransferScreenViewModel TransferVM { get; set; }
        public DepositScreenViewModel DepositVM { get; set; }
        public WithdrawScreenViewModel WithdrawVM { get; set; }
        public PayServicesScreenViewModel PayServicesVM { get; set; }

        public TransactionScreenViewModel TransactionVM { get; set; }
        public SettingsScreenViewModel SettingsVM { get; set; }

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

        // Constructor/body commented out to avoid compilation errors during incremental fixes.
        /*
        //public HomeViewModel()
        {
            SideBarViewModel = new SideBarViewModel();

            DashboardVM = new DashboardScreenViewModel();
            DepositVM = new DepositScreenViewModel();
            TransferVM = new TransferScreenViewModel();
            WithdrawVM = new WithdrawScreenViewModel();
            PayServicesVM = new PayServicesScreenViewModel();
            TransactionVM = new TransactionScreenViewModel();
            SettingsVM = new SettingsScreenViewModel();


            CurrentView = DashboardVM;

            SideBarViewModel.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == nameof(SideBarViewModel.Selected))
                {
                    UpdateCurrentView();
                }
            };
        }
        */

        private void UpdateCurrentView()
        {
            Debug.WriteLine($"UpdateCurrentView called with: {SideBarViewModel.Selected}");

            switch (SideBarViewModel.Selected) 
            {
                case "Dashboard":
                    CurrentView = DashboardVM;
                    break;

                case "Transfer":
                    CurrentView = TransferVM;
                    break;

                case "Deposit":
                    CurrentView = DepositVM;
                    break;

                case "Withdraw":
                    CurrentView = WithdrawVM;
                    break;

                case "PayServices":
                    CurrentView = PayServicesVM;
                    break;

                case "Transaction":
                    CurrentView = TransactionVM;
                    break;

                case "Settings":
                    CurrentView = SettingsVM;
                    break;
            }
        }
    }
}

