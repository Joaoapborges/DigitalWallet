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
    class TransferScreenViewModel : ObservableObject
    {/*
        //para popup
        public event EventHandler<string> RequestErrorPopup;
        public event EventHandler<string> RequestSuccessPopup;


        public ObservableCollection<Card> ListaCartoes { get; set; }
        private Card _sourceCard;
        public Card SourceCard
        {
            get { return _sourceCard; }
            set {_sourceCard = value; OnPropertyChanged();}
        }
        
        private string _recipientCard;
        public string RecipientCard
        {
            get { return _recipientCard; }
            set {_recipientCard = value; OnPropertyChanged();}
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
        
        public ICommand TransferCommand { get; set; }

        public TransferScreenViewModel()
        {
            TransferCommand = new RelayCommand(MakeTransfer, o => true);
            ListaCartoes = new ObservableCollection<Card>();
            CarregarCartoes();
        }

        private async void MakeTransfer(object obj)
        {
            // Validações iniciais (Input)
            if (SourceCard == null)
            {
                RequestErrorPopup?.Invoke(this, "Card is Null!");
                return;
            }

            if (Amount <= 0)
            {
                RequestErrorPopup?.Invoke(this, "Amount must be >0 !");
                return;
            }

            // verifica tamanho do cartao
            if (string.IsNullOrWhiteSpace(RecipientCard) || RecipientCard.Length != 12 || !long.TryParse(RecipientCard, out _))
            {
                RequestErrorPopup?.Invoke(this, "Recipient Card must have exactly 12 numbers!");
                return;
            }

            try
            {
                var newTransaction = new TransactionRequest
                {
                    scrId = SourceCard.id,
                    dstCardNumber = RecipientCard,
                    amount = Amount,
                    entity = 0,
                    reference = "Transfer"
                };

                var api = new ApiService();

                // await aqui pode lançar exceções de rede (Timeouts, DNS, etc)
                bool success = await api.TransactionAsync(newTransaction);

                if (success)
                {
                    RequestSuccessPopup?.Invoke(this, "Successful Transaction!");
                    Amount = 0;
                }
                else
                {
                    RequestErrorPopup?.Invoke(this, "Database failled");
                }
            }
            catch (Exception)
            {
                RequestErrorPopup?.Invoke(this, "An error occurred during the transfer request.");
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
                MessageBox.Show("Nenhum cartão encontrado!"); 
            }
        }*/
    }
}
