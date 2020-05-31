using CarCards.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarCards.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;        

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;            
        }
        
        private DelegateCommand _goToAddCardPage;
        public DelegateCommand GoToAddCardPage => _goToAddCardPage ?? (_goToAddCardPage = new DelegateCommand(async () => await ExecuteIrGoToAddCardPage()));

        private async Task ExecuteIrGoToAddCardPage() => await _navigationService.NavigateAsync("AddCardPage");

        private List<Card> LoadCards()
        {
            return null;
        }
    }
}
