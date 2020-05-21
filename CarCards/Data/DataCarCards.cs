using CarCards.Helpers;
using CarCards.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CarCards.Data
{
    public class DataCarCards
    {
        private readonly LiteDatabase _dataBase;
        private readonly LiteCollection<Card> cards;       

        public DataCarCards()
        {
            _dataBase = new LiteDatabase(DependencyService.Get<IPathDataBase>().FilePath("CarCardsDb.db"));

            cards = (LiteCollection<Card>)_dataBase.GetCollection<Card>();
        }

        public void Add(Card card)
        {
            cards.Insert(card);
        }        
    }
}
