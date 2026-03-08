using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels
{

    public class RegistryViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        // propriedades ligadas a view

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        private string _nif;
        public string Nif
        {
            get => _nif;
            set { _nif = value; OnPropertyChanged(); }
        }

        private string _country;
        public string Country
        {
            get => _country;
            set { _country = value; OnPropertyChanged(); }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        // para ja fica assim
        private string _image = "default.png";


        // Comando associado ao botão do XAML
        public ICommand CreateClientCommand { get; }
        public event EventHandler<string> RequestErrorPopup;
        public event EventHandler<string> RequestSuccessPopup;

        public RegistryViewModel()
        {
            _apiService = new ApiService();


            CreateClientCommand = new RelayCommand(CreateClient, o => true);

            
        }

        public async void CreateClient(object parameter)
        {
            
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Password))
            {
                RequestErrorPopup?.Invoke(this, "Por favor, preenche todos os campos obrigatórios.");
                return;
            }

            var api = new ApiService();
            bool registrySuccess = await api.RegisterClientAsync(Name, Email, Nif, Country, Password);

            if (registrySuccess)
            {
                RequestSuccessPopup?.Invoke(this, "User created successfully");
            }
            else
            {
                RequestErrorPopup?.Invoke(this, "User creation failed");
            }
        }

    }
    }

