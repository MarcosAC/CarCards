using CarCards.Data;
using CarCards.Helpers;
using CarCards.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CarCards.ViewModels
{
    public class MainPageViewModel : BindableBase/*, INavigatedAware*/
    {
        private readonly INavigationService _navigationService;

        private readonly CarCardsData _carCardsData;

        private readonly WiFiConnection _wiFiConection;

        private readonly FireBaseHelper _firebase;

        //public ObservableCollection<Card> Cards { get; set; }
        public List<Card> Cards { get; set; }


        public MainPageViewModel(INavigationService navigationService, CarCardsData carCardsData)
        {
            _navigationService = navigationService;

            _carCardsData = carCardsData;

            _wiFiConection = new WiFiConnection();

            _firebase = new FireBaseHelper();

            //SyncLocalCardsList();

            Cards = LoadCardsAsync();
        }
        
        private DelegateCommand _goAddCardPageCommand;
        public DelegateCommand GoAddCardPageCommand =>
            _goAddCardPageCommand ?? (_goAddCardPageCommand = new DelegateCommand(async () => await ExecuteGoAddCardPageCommand()));

        private async Task ExecuteGoAddCardPageCommand() => await _navigationService.NavigateAsync("AddCardPage");

        //public void OnNavigatedTo(INavigationParameters parameters) => Cards = new ObservableCollection<Card>(LoadCards());

        //public void OnNavigatedTo(INavigationParameters parameters) => Cards = new List<Card>((IEnumerable<Card>)LoadCards());

        public void OnNavigatedFrom(INavigationParameters parameters) { }

        //public ObservableCollection<Card> LoadCards()
        //{
            //if (_wiFiConection.IsConnected())
                //return _firebase.GetAll();

            //return _carCardsData.GetAll();
        //}

        public List<Card> LoadCardsAsync()
        {
            var dados = new List<Card>();

            if (_wiFiConection.IsConnected())
            {
                var lista = _firebase.ListCardsAsync().GetAwaiter();

                foreach (var item in lista.GetResult())
                {
                    dados.Add(item);
                }
            }               

            return dados;

            //return _carCardsData.GetAll();
        }

        private void SyncLocalCardsList()
        {
            var localCardList = _carCardsData.GetAll();
            var firebaseCardList = _firebase.GetAll();

            if (localCardList.Count > firebaseCardList.Count)
                _firebase.UpdateCardsList(localCardList).GetAwaiter();
        }
    }
}
