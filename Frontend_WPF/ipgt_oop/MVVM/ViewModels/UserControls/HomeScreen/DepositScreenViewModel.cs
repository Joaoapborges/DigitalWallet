using ipgt_oop.Core;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    class DepositScreenViewModel : ObservableObject
    {/*
        public ObservableCollection<Card> ListaCartoes { get; set; }

        //cartõ escolhido

        private Card _selectedCard;
        public Card SelectedCard
        {
            get { return _selectedCard; }
            set {_selectedCard = value; OnPropertyChanged();
            }
        }

        // valor do deposito 
        private decimal _amount;
        public decimal Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }

        // comando para botao depositar
        public ICommand DepositCommand { get; set; }

        // para pop up
        public event EventHandler<string> RequestErrorPopup;
        public event EventHandler<string> RequestSuccessPopup;

        public DepositScreenViewModel()
        {
            ListaCartoes = new ObservableCollection<Card>();
            LoadCards();

            // Inicializa o comando (Assumindo que tens RelayCommand no teu Core)
            DepositCommand = new RelayCommand(MakeDeposit, o => true);
        }

        private async void MakeDeposit(object obj)
        {

            if (SelectedCard == null)
            {
                RequestErrorPopup?.Invoke(this, "Select Card is Null!");
                return;
            }

            // 2. Verificar se o Valor falhou
            if (Amount <= 0)
            {
                RequestErrorPopup?.Invoke(this, "Amount must be >0!");
                return;
            }

            var newTransaction = new TransactionRequest
            {
                scrId = -1,
                dstCardNumber = SelectedCard.number, 
                amount = Amount,
                entity = 0,            
                reference = "Deposit"
            };

            
            var api = new ApiService();
            bool success = await api.TransactionAsync(newTransaction);

            // 4. Verificar o resultado
            if (success)
            {
                // colocar popup

                RequestSuccessPopup?.Invoke(this, "Successful Deposit!");
                Amount = 0; // Limpar o campo do valor
            }
            else
            {
                // colocar pop up
                RequestErrorPopup?.Invoke(this, "Database Failed!");
            }
        }

        private async void LoadCards()
        {
            var api = new ApiService();

            var cardList = await api.GetCardsAsync();
            
            SelectedCard = cardList[0];
            ListaCartoes.Clear();
            foreach (var card in cardList)
            {
                ListaCartoes.Add(card);
                
            }
                    
        }*/

    }
}
