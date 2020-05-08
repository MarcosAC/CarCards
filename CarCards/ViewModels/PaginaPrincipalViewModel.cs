using CarCards.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarCards.ViewModels
{
    public class PaginaPrincipalViewModel: BaseViewModel
    {
        public ObservableCollection<Carro> Carros { get; }

        public PaginaPrincipalViewModel()
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
        }
    }
}
