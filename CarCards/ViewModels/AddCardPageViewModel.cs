using CarCards.Data;
using CarCards.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarCards.ViewModels
{
    public class AddCardPageViewModel : BindableBase
    {
        readonly DataCarCards DataCarCards = new DataCarCards();

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
                Motor = Motor
            };

            DataCarCards.Add(card);

            App.Current.MainPage.DisplayAlert("Grarvar Dados", "Funcionou", "Ok");
        }
    }
}
