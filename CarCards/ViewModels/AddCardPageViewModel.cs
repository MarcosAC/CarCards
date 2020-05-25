using CarCards.Data;
using CarCards.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarCards.ViewModels
{
    public class AddCardPageViewModel : BindableBase
    {
        readonly DataCarCards DataCarCards = new DataCarCards();

        private bool _visible = true;
        public bool Visible
        {
            get => _visible;
            set => SetProperty(ref _visible, value);
        }

        private ImageSource _foto;
        public ImageSource Foto
        {
            get => _foto;
            set => SetProperty(ref _foto, value);
        }

        private string _caminhoFoto;
        public string CaminhoFoto
        {
            get => _caminhoFoto;
            set => SetProperty(ref _caminhoFoto, value);
        }

        private string _nomeCarro;
        public string NomeCarro
        {
            get => _nomeCarro;
            set => SetProperty(ref _nomeCarro, value);
        }

        private string _ano;
        public string Ano
        {
            get => _ano;
            set => SetProperty(ref _ano, value); 
        }

        private string _velocidade;
        public string Velocidade
        { 
            get => _velocidade;
            set => SetProperty(ref _velocidade, value);
        }

        private string _aceleracao;
        public string Aceleracao
        { 
            get => _aceleracao; 
            set => SetProperty(ref _aceleracao, value); 
        }

        private string _potencia;
        public string Potencia
        { 
            get => _potencia;
            set => SetProperty(ref _potencia, value);
        }

        private string _cilindradas;
        public string Cilindradas
        { 
            get => _cilindradas;
            set => SetProperty(ref _cilindradas, value);
        }

        private string _motor;
        public string Motor
        { 
            get => _motor;
            set => SetProperty(ref _motor, value);
        }

        private void CarregarFoto(MediaFile file)
        {
            if (file == null)
                return;
            else
                Visible = false;

            Foto = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private DelegateCommand _takePhotoCommand;
        public DelegateCommand TakePhotoCommand => _takePhotoCommand ?? (new DelegateCommand(async () => await ExecuteTakePhotoCommand()));

        private async Task ExecuteTakePhotoCommand()
        {
            if (!await App.Current.MainPage.DisplayAlert("Adicionar Imagem ou Foto",
                                                         "Deseja adicionar uma imagem do arquivo ou tirar uma foto?",
                                                         "Adicionar Imagem", "Tirar Foto"))
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

                CaminhoFoto = file.Path;

                CarregarFoto(file);
            }
            else
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium,

                });

                if (file == null)
                    return;

                CarregarFoto(file);
            }
        }

        private DelegateCommand _addCardCommand;
        public DelegateCommand AddCardCommand => _addCardCommand ?? (new DelegateCommand(() => ExecuteAddCardCommand()));

        private void ExecuteAddCardCommand()
        {
            var card = new Card
            {
                NomeCarro = NomeCarro,
                Ano = Ano,
                Velocidade = Velocidade,
                Aceleracao = Aceleracao,
                Potencia = Potencia,
                Cilindradas = Cilindradas,
                Motor = Motor,
                CaminhoFoto = CaminhoFoto
            };

            DataCarCards.Add(card);

           App.Current.MainPage.DisplayAlert("Grarvar Dados", "Funcionou", "Ok");
        }
    }
}
