﻿using CarCards.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CarCards.Helpers
{
    public class FireBaseHelper
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://carcards-xxxx.firebaseio.com/");

        public ObservableCollection<Card> Cards { get; set; }

        public FireBaseHelper()
        {
            Cards = new ObservableCollection<Card>();
        }

        public async Task AddCard(Card card) => await firebase.Child("Cards").PostAsync<Card>(card);

        public ObservableCollection<Card> GetAll()
        {
            return firebase
                   .Child("Cards")
                   .AsObservable<Card>()
                   .AsObservableCollection();
        }

        #region Código para exemplo
        /*
        public async Task UpdateCardsList(ObservableCollection<Card> cards)
        {
            await firebase
                  .Child("Cards")
                  .PutAsync(cards);
        }

        public async Task<List<Card>> ListCardsAsync()
        {
            return (await firebase
                          .Child("Cards")
                          .OnceAsync<Card>()).Select(item => new Card
                          {
                              Marca = item.Object.Marca,
                              NomeCarro = item.Object.NomeCarro,
                              Ano = item.Object.Ano,
                              Velocidade = item.Object.Velocidade,
                              Aceleracao = item.Object.Aceleracao,
                              Potencia = item.Object.Potencia,
                              Cilindradas = item.Object.Cilindradas,
                              Motor = item.Object.Motor,
                              CaminhoFoto = item.Object.CaminhoFoto
                          }).ToList();
        }
        */
        #endregion
    }
}
