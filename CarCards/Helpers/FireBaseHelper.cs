using CarCards.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarCards.Helpers
{
    public class FireBaseHelper
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://carcards-d6bc8.firebaseio.com/");

        public ObservableCollection<Card> Cards { get; set; }

        public FireBaseHelper()
        {
            Cards = new ObservableCollection<Card>();
        }

        public async Task AddCard(Card card) => await firebase.Child("Cards").PostAsync<Card>(card);

        public ObservableCollection<Card> GetAll()
        {
            var dados =  firebase
                   .Child("Cards")
                   .AsObservable<Card>()
                   .AsObservableCollection();

            return dados;
        }

        public async Task UpdateCardsList(ObservableCollection<Card> cards)
        {
            await firebase
                .Child("Cards")
                .PutAsync(cards);
        }

        //public async Task AddCard(Card card)
        //{
        //    await firebase
        //        .Child("Cards")
        //        .PostAsync<Card>(card);
        //}

        public async Task<List<Card>> ListCardsAsync()
        {
            return ((List<Card>)await firebase
                .Child("Cards")
                .OnceAsync<Card>());
        }
    }
}
