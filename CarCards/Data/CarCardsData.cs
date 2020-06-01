using CarCards.Models;
using Realms;
using System.Collections.Generic;
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

        public List<Card> GetAll()
        {
            return CarCardsDb.All<Card>().ToList();
        }
    }
}
