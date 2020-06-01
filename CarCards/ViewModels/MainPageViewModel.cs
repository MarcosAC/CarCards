using CarCards.Data;
using CarCards.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CarCards.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private readonly CarCardsData carCardsData;

        public ObservableCollection<Card> Cards { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            carCardsData = new CarCardsData();

<<<<<<< HEAD
            Cards = new ObservableCollection<Card>(dataCarCards.GetAll());
=======
            Cards = new ObservableCollection<Card>(carCardsData.GetAll());
>>>>>>> RealmDB
        }
        
        private DelegateCommand _goToAddCardPage;
        public DelegateCommand GoToAddCardPage => _goToAddCardPage ?? (_goToAddCardPage = new DelegateCommand(async () => await ExecuteIrGoToAddCardPage()));

<<<<<<< HEAD
        private async Task ExecuteIrGoToAddCardPage() => await _navigationService.NavigateAsync("AddCardPage");        
=======
        private async Task ExecuteIrGoToAddCardPage() => await _navigationService.NavigateAsync("AddCardPage");
>>>>>>> RealmDB
    }
}
