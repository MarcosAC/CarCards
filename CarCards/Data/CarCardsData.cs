using CarCards.Models;
using Realms;
using System.Collections.ObjectModel;
using System.Linq;

namespace CarCards.Data
{
    public class CarCardsData
    {
        protected Realm CarCardsDb;

        public CarCardsData()
        {
            CarCardsDb = Realm.GetInstance();
        }

        public void Add(Card card)
        {
            var cards = CarCardsDb.All<Card>().ToList();

            CarCardsDb.Write(() => card = CarCardsDb.Add(card));
        }

        public ObservableCollection<Card> GetAll()
        {
            var listCards = CarCardsDb.All<Card>().ToList();

            var cards = new ObservableCollection<Card>();

            foreach (var item in listCards)
                cards.Add(item);

            return cards;
        }
    }
}
