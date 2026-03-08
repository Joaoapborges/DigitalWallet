using ipgt_oop.Core;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels.UserControls.Popups
{
    internal class ServicePayPopupViewModel : ObservableObject
    {/*

        private string _catName;

        public string CatName
        {
            get { return _catName; }
            set
            {
                _catName = value;
                OnPropertyChanged();
            }
        }

        // popups
        public event EventHandler<string> RequestErrorPopup;

        public event EventHandler<string> RequestSuccessPopup;


        //API

        private ApiService _apiService;

        private string _reference;
        public string Reference
        {
            get { return _reference; }
            set { _reference = value; OnPropertyChanged(); }
        }

        private string _entity;
        public string Entity
        {
            get => _entity;
            set
            {
                _entity = value;
                OnPropertyChanged();
            }
        }

        private string _amount;
        public string Amount
        {
            get => _amount;
            set { _amount = value; OnPropertyChanged(); } 
            
        }

        // get => _amount; ou get { return _reference; } é igual

        // cartões para a combobox
        public ObservableCollection<Card> ListaCartoes { get; set; }
        private Card _sourceCard;
        public Card SourceCard
        {
            get { return _sourceCard; }
            set { _sourceCard = value; OnPropertyChanged(); }
        }

        public ICommand PayCommand { get; set; }

        public ServicePayPopupViewModel()
        {
            _apiService = new ApiService();
            PayCommand = new RelayCommand(ExecutePay, o => true);
            ListaCartoes = new ObservableCollection<Card>();
            CarregarCartoes();
        }

        private async void ExecutePay(object obj)
        {
            try
            {
                    
                    if (SourceCard == null)
                    {                        
                        RequestErrorPopup?.Invoke(this, "Card is empty!");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(Reference))
                    {
                        RequestErrorPopup?.Invoke(this, "Reference is empty!");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(Amount))
                    {
                        RequestErrorPopup?.Invoke(this, "Amount is empty!");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(Entity))
                    {
                        RequestErrorPopup?.Invoke(this, "Entity is empty!");
                        return;
                    }

                    // Se o utilizador escrever "50.00", isto garante que funciona em qualquer PC
                    if (!decimal.TryParse(Amount.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal amountValue))
                {
                    RequestErrorPopup?.Invoke(this, "Invali amount format! Try: 10.00");
                    return;
                }

                //  Entidade
                if (!int.TryParse(Entity.Trim(), out int entityValue))
                {
                    RequestErrorPopup?.Invoke(this, "Invalid Entity!");
                    return;
                }

                //Criar o Objeto 
                var transaction = new TransactionRequest
                {
                    scrId = SourceCard.id,
                    dstCardNumber = "",
                    amount = amountValue,
                    entity = entityValue,
                    reference = Reference.Trim() // Remove espaços extra da referência
                };

                // Chamada API
                bool success = await _apiService.TransactionAsync(transaction);

                if (success)
                {
                    RequestSuccessPopup?.Invoke(this, "Payment Successful!");
                    

                    // Limpar os campos 
                    Reference = string.Empty;
                    Entity = string.Empty;
                    Amount = string.Empty;
                }
                else
                {
                    RequestErrorPopup?.Invoke(this, "Payment faild check Reference Number!");
                }
            }
            catch (Exception ex)
            {
                // Apanha erros de rede ou crashes inesperados
                RequestErrorPopup?.Invoke(this, "Database Error!");
            }
        }



        private async void CarregarCartoes()
        {
            var api = new ApiService();

            var cartoes = await api.GetCardsAsync();

            SourceCard = cartoes[0];
            ListaCartoes.Clear();
            foreach (var cartao in cartoes)
            {
                ListaCartoes.Add(cartao);
            }

            if (ListaCartoes.Count == 0)
            {
                // colocar pop up
                RequestErrorPopup?.Invoke(this, "No card found!");
            }
        }*/

    }
}
