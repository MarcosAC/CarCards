using CarCards.Data;
using CarCards.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace CarCards.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        readonly DataCarCards DataCarCards = new DataCarCards();

        public ObservableCollection<Card> Cards { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Cards = new ObservableCollection<Card>(LoadCards());
        }
        
        private DelegateCommand _goToAddCardPage;
        public DelegateCommand GoToCarPage => _goToAddCardPage ?? (_goToAddCardPage = new DelegateCommand(async () => await ExecuteIrAdicionarCardPage()));

        private async Task ExecuteIrAdicionarCardPage() => await _navigationService.NavigateAsync("AddCardPage");

        private List<Card> LoadCards()
        {
            return DataCarCards.GetAll();
        }
    }
}
