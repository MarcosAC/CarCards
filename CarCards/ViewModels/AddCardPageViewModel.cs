﻿using CarCards.Data;
using CarCards.Helpers;
using CarCards.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarCards.ViewModels
{
    public class AddCardPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;

        private readonly IPageDialogService _pageDialogService;

        private readonly DbLocal dbLocal;

        private readonly WiFiConnection wiFiConection;

        private readonly FireBaseHelper firebase;          

        public AddCardPageViewModel(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            _navigationService = navigationService;

            _pageDialogService = pageDialogService;

            dbLocal = new DbLocal();

            wiFiConection = new WiFiConnection();

            firebase = new FireBaseHelper();
        }

        private bool _imageButtonIsVisible = true;
        public bool ImageButtonIsVisible
        {
            get => _imageButtonIsVisible;
            set => SetProperty(ref _imageButtonIsVisible, value);
        }        

        private string _marca;
        public string Marca 
        {
            get => _marca;
            set => SetProperty(ref _marca, value);
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

                LoadPhoto(file);
            }
            else
            {
                var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
                {
                    PhotoSize = PhotoSize.Medium
                });

                if (file == null)
                    return;

                CaminhoFoto = file.Path;

                LoadPhoto(file);
            }
        }

        private DelegateCommand _addCardCommand;
        public DelegateCommand AddCardCommand => _addCardCommand ?? (_addCardCommand = new DelegateCommand(async () => await ExecuteAddCardCommand()));

        private async Task ExecuteAddCardCommand()
        {
            var card = new Card
            {
                Marca = Marca,
                NomeCarro = NomeCarro,
                Ano = Ano,
                Velocidade = Velocidade,
                Aceleracao = Aceleracao,
                Potencia = Potencia,
                Cilindradas = Cilindradas,
                Motor = Motor,
                CaminhoFoto = CaminhoFoto
            };

            try
            {
                if (wiFiConection.IsConnected())
                    await firebase.AddCard(card);

                dbLocal.Add(card);

                await _pageDialogService.DisplayAlertAsync("Salvar Card", "Card salvo com sucesso!", "Ok");
            }
            catch (System.Exception)
            {
               await _pageDialogService.DisplayAlertAsync("Salvar Card", "Erro ao salvar Card!", "Ok");
            }

            await _navigationService.NavigateAsync("MainPage");
        }

        private DelegateCommand _goBackMainPageCommand;
        public DelegateCommand GoBackMainPageCommand => 
            _goBackMainPageCommand ?? (_goBackMainPageCommand = new DelegateCommand(async () => await ExecuteGoBackMainPageCommand()));

        private async Task ExecuteGoBackMainPageCommand() => await _navigationService.GoBackAsync();

        private void LoadPhoto(MediaFile file)
        {
            if (file == null)
                return;
            else
                ImageButtonIsVisible = false;

            Foto = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }
    }
}
