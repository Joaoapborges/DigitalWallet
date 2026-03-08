using ipgt_oop.Core;
using ipgt_oop.MVVM.ViewModels.UserControls.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels
{
    internal class LoginViewModel : ObservableObject
    {
        private DataTemplate _currentTemplate;
        public DataTemplate CurrentTemplate
        {
            get => _currentTemplate;
            set
            {
                _currentTemplate = value;
                OnPropertyChanged();
            }
        }

        private string _selectedSegment; // 0 = ManualEntry, 1 = QuickSelect

        public string SelectedSegment
        {
            get => _selectedSegment;
            set
            {
                _selectedSegment = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectSegmentCommand { get; }

        
        public LoginViewModel()
        {
            SelectSegmentCommand = new RelayCommand(
                param => { if (param != null)
                    {
                        SelectedSegment = param as string;
                        UpdateTemplate();
                    }
                },
                null
                );
        }
        
        private void UpdateTemplate()
        {
            if (SelectedSegment == "0")
                CurrentTemplate = Application.Current.Resources["ManualEntryTemplate"] as DataTemplate ?? null!;
            else if (SelectedSegment == "1")
                CurrentTemplate = Application.Current.Resources["QuickSelectTemplate"] as DataTemplate ?? null!;
        }
    }
}
