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

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            _carCardsData = new CarCardsData(); 
            
            Cards = new ObservableCollection<Card>(_carCardsData.GetAll());
        }
        
        private DelegateCommand _goToAddCardPage;
        public DelegateCommand GoToAddCardPage => _goToAddCardPage ?? (_goToAddCardPage = new DelegateCommand(async () => await ExecuteIrGoToAddCardPage()));

        private async Task ExecuteIrGoToAddCardPage() => await _navigationService.NavigateAsync("AddCardPage");

        public void OnNavigatedTo(INavigationParameters parameters) => Cards = new ObservableCollection<Card>(_carCardsData.GetAll());

        public void OnNavigatedFrom(INavigationParameters parameters) { }
    }
}
