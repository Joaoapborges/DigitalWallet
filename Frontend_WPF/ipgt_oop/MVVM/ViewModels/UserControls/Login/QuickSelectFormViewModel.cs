using ipgt_oop.Core;
using ipgt_oop.Helpers;
using ipgt_oop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace ipgt_oop.MVVM.ViewModels.UserControls.Login
{
    internal class QuickSelectFormViewModel : ObservableObject
    {/*
        private readonly ApiService _apiService;

        public event EventHandler RequestHomeWindow;
        public event EventHandler<string> RequestPopup;

        public ObservableCollection<string> SavedUsers { get; set; }

        private string _selectedUser;

        public string SelectedUser
        {
            get => _selectedUser;
            set => SetProperty(ref _selectedUser, value);
        }

        private string _password;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }


        public ICommand QuickLoginCommand { get; }
                

        public QuickSelectFormViewModel()
        {
            _apiService = new ApiService();
            SavedUsers = new ObservableCollection<string>();

            QuickLoginCommand = new RelayCommand(o => FazerLogin(), o => true);

            LoadUsers();
        }

        private void LoadUsers()
        {
            var users = UserStore.LoadUsernames();

            foreach (var user in users)
            {
                SavedUsers.Add(user);
            }

            if (SavedUsers.Count > 0)
            {
                SelectedUser = SavedUsers[0];
            }

        }

        private async void FazerLogin()
        {
            
            if (string.IsNullOrEmpty(SelectedUser) || string.IsNullOrEmpty(Password))
            {
                RequestPopup?.Invoke(this, "Seleciona um utilizador e insere a password.");
                return;
            }

            var api = new ApiService();

            bool loginSucesso = await api.LoginAsync(SelectedUser, Password);

            if (loginSucesso)
            {
                Console.WriteLine("PASS certa");
                RequestHomeWindow?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("PASS ERRADA");
                RequestPopup?.Invoke(this, "Password incorreta ou erro de conexão.");
            }
        }*/
    }
}
