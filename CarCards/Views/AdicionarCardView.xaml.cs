using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarCardView : ContentPage
    {
        public AdicionarCardView(MediaFile file = null)
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
            else
                TirarFoto.IsVisible = false;

            CarregarFoto(file);

            //Imagem.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});
        }
    }
}