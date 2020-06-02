using CarCards.Data;
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

        private readonly CarCardsData _carCardsData;

        public ObservableCollection<Card> Cards { get; set; }

        public MainPageViewModel(INavigationService navigationService, CarCardsData carCardsData)
        {
            _navigationService = navigationService;

            _carCardsData = carCardsData; 
            
            Cards = new ObservableCollection<Card>(_carCardsData.GetAll());
        }
        
        private DelegateCommand _goAddCardPageCommand;
        public DelegateCommand GoAddCardPageCommand =>
            _goAddCardPageCommand ?? (_goAddCardPageCommand = new DelegateCommand(async () => await ExecuteGoAddCardPageCommand()));

        private async Task ExecuteGoAddCardPageCommand() => await _navigationService.NavigateAsync("AddCardPage");

        public void OnNavigatedTo(INavigationParameters parameters) => Cards = new ObservableCollection<Card>(_carCardsData.GetAll());

        public void OnNavigatedFrom(INavigationParameters parameters) { }
    }
}
