﻿using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdicionarCardView : ContentPage
    {
        public AdicionarCardView()
        {
            InitializeComponent();
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

            Imagem.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}