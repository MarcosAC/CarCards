using CarCards.Helpers;
using CarCards.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CarCards.Data
{
    public class DataCarCards
    {
        protected LiteDatabase dataBase;

        LiteCollection<Card> cards;      

        public DataCarCards()
        {
            dataBase = new LiteDatabase(DependencyService.Get<IPathDataBase>().FilePath("CarCardsDb.db"));

            //cards = (LiteCollection<Card>)dataBase.GetCollection<Card>();
        }

        public void Add(Card card)
        {
            //card.Id = Guid.NewGuid().ToString();

            var cards = (LiteCollection<Card>)dataBase.GetCollection<Card>();

            cards.Insert(card);            
        }  
        
        public List<Card> GetAll()
        {
            return cards.FindAll().ToList();
        }
    }
}
