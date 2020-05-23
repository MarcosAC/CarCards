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
        
        public ObservableCollection<Card> Cards { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Cards = new ObservableCollection<Card>
            {
                new Card
                {
                    NomeCarro = "Opala Comodoro",
                    Ano = "1979",
                    //Cor = "Branco",
                    Velocidade = "165,4 km/h",
                },

                new Card
                {
                    NomeCarro = "Opala Comodoro",
                    Ano = "1979",
                   // Cor = "Branco",
                    Velocidade = "165,4 km/h",
                },

                new Card
                {
                    NomeCarro = "Opala Comodoro",
                    Ano = "1979",
                    //Cor = "Branco",
                    Velocidade = "165,4 km/h",
                },

                new Card
                {
                    NomeCarro = "Opala Comodoro",
                    Ano = "1979",
                    //Cor = "Branco",
                    Velocidade = "165,4 km/h",
                },

                new Card
                {
                    NomeCarro = "Opala Comodoro",
                    Ano = "1979",
                    //Cor = "Branco",
                    Velocidade = "165,4 km/h",
                }
            };

        }
        
        private DelegateCommand _goToAddCardPage;
        public DelegateCommand GoToCarPage => _goToAddCardPage ?? (_goToAddCardPage = new DelegateCommand(async () => await ExecuteIrAdicionarCardPage()));

        private async Task ExecuteIrAdicionarCardPage() => await _navigationService.NavigateAsync("AddCardPage");
    }
}
