using CarCards.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace CarCards.ViewModels
{
    public class PrincipalViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        
        public ObservableCollection<Carro> Carros { get; }

        public PrincipalViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Carros = new ObservableCollection<Carro>
            {
                new Carro
                {
                    Nome = "Opala Comodoro",
                    Ano = "1979",
                    //Cor = "Branco",
                    Velocidade = "165,4 km/h",
                },

                new Carro
                {
                    Nome = "Opala Comodoro",
                    Ano = "1979",
                   // Cor = "Branco",
                    Velocidade = "165,4 km/h",
                },

                new Carro
                {
                    Nome = "Opala Comodoro",
                    Ano = "1979",
                    //Cor = "Branco",
                    Velocidade = "165,4 km/h",
                },

                new Carro
                {
                    Nome = "Opala Comodoro",
                    Ano = "1979",
                    //Cor = "Branco",
                    Velocidade = "165,4 km/h",
                },

                new Carro
                {
                    Nome = "Opala Comodoro",
                    Ano = "1979",
                    //Cor = "Branco",
                    Velocidade = "165,4 km/h",
                }
            };

        }
        
        private DelegateCommand _irAdicionarCardPage;
        public DelegateCommand IrAdicionarCardPage => 
            _irAdicionarCardPage ?? (_irAdicionarCardPage = new DelegateCommand(async () => await ExecuteIrAdicionarCardPage()));

        private async Task ExecuteIrAdicionarCardPage() => await _navigationService.NavigateAsync("AdicionarCardPage");
    }
}
