using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ipgt_oop.Core;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    
    class WithdrawScreenViewModel : ObservableObject
    {/*
        public ObservableCollection<Card> ListaCartoes { get; set; }

        private Card _selectedCard;
        public Card SelectedCard
        {
            get { return _selectedCard; }
            set {_selectedCard = value; OnPropertyChanged();
            }
        }
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


        public event EventHandler<string> RequestErrorPopup;

        public event EventHandler<string> RequestSuccessPopup;

        public ICommand WithdrawCommand { get; set; }
        
        
        public WithdrawScreenViewModel()
        {
            ListaCartoes = new ObservableCollection<Card>();
            CarregarCartoes();
            
            WithdrawCommand = new RelayCommand(MakeWithdraw, o => true);
        }
        
        
        
        private async void MakeWithdraw(object obj)
        {

            if (SelectedCard == null)
            {
                RequestErrorPopup?.Invoke(this, "Chose a card!");
                return;
            }

            // 2. Verificar se o Valor falhou
            if (Amount <= 0)
            {
                RequestErrorPopup?.Invoke(this, "Amount must be >0");
                return;
            }
            
            //3. Verificar se o valor a ser retirado a maior que a quantia no cartao
            if (Amount > SelectedCard.balance)
            {
                RequestErrorPopup?.Invoke(this, "You dont have that much money!");
                return;
            }

            var novaTransacao = new TransactionRequest
            {
                scrId = SelectedCard.id,
                dstCardNumber = "", 
                amount = Amount,
                entity = 0,            
                reference = "Withdraw"
            };

            
            var api = new ApiService();
            bool sucesso = await api.TransactionAsync(novaTransacao);

            // 4. Verificar o resultado
            if (sucesso)
            {
                // colocar popup
                RequestSuccessPopup?.Invoke(this, "Sucessfull Withdraw!");
                Amount = 0; // Limpar o campo do valor
            }
            else
            {
                // colocar pop up
                RequestErrorPopup?.Invoke(this, "Database Error!");
            }
        }
        
        private async void CarregarCartoes()
        {
            var api = new ApiService();

            var cardList = await api.GetCardsAsync();


            SelectedCard = cardList[0];
            ListaCartoes.Clear();
            foreach (var cartao in cardList)
            {
                ListaCartoes.Add(cartao);
            }

            if (ListaCartoes.Count == 0)
            {
                // colocar pop up
                RequestErrorPopup?.Invoke(this, "No card Found!");
            }
        }*/
    }
}
