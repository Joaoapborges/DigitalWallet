using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    class TransactionScreenViewModel
    {/*
        internal Action<object, string> RequestErrorPopup;

        public Action<object, string> RequestSuccessPopup { get; internal set; }
        public ObservableCollection<TransactionRecord> TransactionsList { get; set; }
        

        public TransactionScreenViewModel()
        {
            TransactionsList = new ObservableCollection<TransactionRecord>();
            
            LoadTransactions();
        }
        
        private async void LoadTransactions()
        {
            var api = new ApiService();
            
            var transactions = await api.GetTransactionsAsync();

            if (transactions == null)
            {
                TransactionsList.Clear();
            }
            
            foreach (var transaction in transactions)
            {
                var viewItem = new TransactionRecord
                {
                    Description = transaction.Description,
                    Type = transaction.Type,
                    Data = transaction.Date,
                    Amount = transaction.Amount
                };
                
                if (transaction.Type == "Withdraw")
                {
                    // If Withdraw, fetch Source ID
                    if (transaction.SourceCard != null)
                    {
                        viewItem.Id = transaction.SourceCard.Id;
                    }
                }
                else if (transaction.Type == "Deposit")
                {
                    // If Deposit, fetch Destiny ID
                    if (transaction.DestinyCard != null)
                    {
                        viewItem.Id = transaction.DestinyCard.Id;
                    }
                }
                else // "Transfer" or generic Transaction
                {
                    // Default to Source ID
                    if (transaction.SourceCard != null)
                    {
                        viewItem.Id = transaction.SourceCard.Id;
                    }
                }
                
                TransactionsList.Add(viewItem);
            }

        }*/
    }
}
