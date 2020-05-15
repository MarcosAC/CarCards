using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarCardPage : ContentPage
    {
        public AdicionarCardPage(MediaFile file = null)
        {
            InitializeComponent();

            CarregarFoto(file);
        }

        private void CarregarFoto(MediaFile file)
        {
            if (file == null)
                return;
            else
                TirarFoto.IsVisible = false;

            Imagem.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void TirarFoto_Click(object sender, System.EventArgs e)
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
                else
                    TirarFoto.IsVisible = false;

                CarregarFoto(file);
            }
        }
    }
}