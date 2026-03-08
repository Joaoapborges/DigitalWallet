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


namespace ipgt_oop.MVVM.ViewModels.UserControls.Popups
{
    internal class DeletecardViewModel : ObservableObject
    {/*
        // Lista para a ComboBox
        public ObservableCollection<Card> CardsList { get; set; }

        private Card _selectedCard;
        public Card SelectedCard
        {
            get => _selectedCard;
            set { _selectedCard = value; OnPropertyChanged(); }
        }

        
        public ICommand DeleteCardCommand { get; } 
      
        public Action CloseAction { get; set; }

        public DeletecardViewModel()
        {
            CardsList = new ObservableCollection<Card>();
        
            DeleteCardCommand = new RelayCommand(o => ApagarCartao(), o => true);

            LoadCards();
        }

        private async void LoadCards()
        {
            var api = new ApiService();
            var cards = await api.GetCardsAsync();

            CardsList.Clear();
            foreach (var c in cards)
            {
                CardsList.Add(c);
            }
        }

        private async void ApagarCartao()
        {
            if (SelectedCard == null)
            {
                // colocar popup
                MessageBox.Show("Por favor selecione um cartão.");
                return;
            }

            
            var api = new ApiService();
            // passar nr cartao
            bool sucesso = await api.DeleteCardAsync(SelectedCard.number);

            
            if (sucesso)
            {
                //colocar popup
                MessageBox.Show("Cartão eliminado com sucesso!");
            }
            else
            {
                // colocar popup
                MessageBox.Show("Erro ao eliminar o cartão. Tente novamente.");
            }
        }*/


    }
}
