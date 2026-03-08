using ipgt_oop.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ipgt_oop.MVVM.Models;
using ipgt_oop.Services;

namespace ipgt_oop.MVVM.ViewModels.UserControls.HomeScreen
{
    class DashboardScreenViewModel : ObservableObject
    {/*
        private Card _selectedCard;
        public Card SelectedCard
        {
            get => _selectedCard;
            set {_selectedCard = value; OnPropertyChanged(nameof(SelectedCard)); OnPropertyChanged(nameof(Balance)); }
        }

        public string Balance => SelectedCard != null
            ? SelectedCard.balance.ToString("C")
            : "$0.00";
        
        public ObservableCollection<Card> ListaCartoes { get; set; }
        public DashboardScreenViewModel()
        {
            ListaCartoes = new ObservableCollection<Card>();
            CarregarCartoes();
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
        }*/
    }
}
