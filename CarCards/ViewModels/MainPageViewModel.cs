﻿using CarCards.Data;
using CarCards.Helpers;
using CarCards.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CarCards.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigatedAware
    {
        private readonly INavigationService _navigationService;

        private readonly DbLocal carCardsData;

        private readonly WiFiConnection wiFiConection;

        private readonly FireBaseHelper firebase;

        public ObservableCollection<Card> Cards { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            carCardsData = new DbLocal();

            wiFiConection = new WiFiConnection();

            firebase = new FireBaseHelper();

            Cards = LoadCards();
        }
        
        private DelegateCommand _goAddCardPageCommand;
        public DelegateCommand GoAddCardPageCommand =>
            _goAddCardPageCommand ?? (_goAddCardPageCommand = new DelegateCommand(async () => await ExecuteGoAddCardPageCommand()));

        private async Task ExecuteGoAddCardPageCommand() => await _navigationService.NavigateAsync("AddCardPage");

        public void OnNavigatedTo(INavigationParameters parameters) => Cards = new ObservableCollection<Card>(LoadCards());

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        public ObservableCollection<Card> LoadCards()
        {
            if (wiFiConection.IsConnected())
                return firebase.GetAll();

            return carCardsData.GetAll();
        }
    }
}
