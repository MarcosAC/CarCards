using CarCards.Models;
using CarCards.Views;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace CarCards.ViewModels
{
    public class PrincipalPageViewModel: BindableBase
    {
        public PrincipalPageViewModel(INavigationService navigationService)
        {
        }

        public ObservableCollection<Carro> Carros { get; }

        public PrincipalPageViewModel()
        {
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

        private Command _tirarFotoCommand;
        public Command TirarFotoCommand =>
            _tirarFotoCommand ?? (_tirarFotoCommand = new Command(async () => await ExecuteTirarFotoCommand()));

        private async Task ExecuteTirarFotoCommand()
        {
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "CarCardsImg",
                SaveToAlbum = false,
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                DefaultCamera = CameraDevice.Rear
            });

            if (file == null)
                return;

            await App.Current.MainPage.Navigation.PushAsync(new AdicionarCardView(file));
        }

        private Command _irPaginaAdionarCarro;
        public Command IrPaginaAdionarCarro =>
            _irPaginaAdionarCarro ?? (_irPaginaAdionarCarro = new Command(async () => await ExecuteIrPaginaAdionarCarro()));

        private async Task ExecuteIrPaginaAdionarCarro()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AdicionarCardView(null));
        }
    }
}
