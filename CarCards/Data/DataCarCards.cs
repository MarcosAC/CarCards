using CarCards.Helpers;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CarCards.Data
{
    public class DataCarCards
    {
        private readonly LiteDatabase _dataBase;

        public DataCarCards()
        {
            _dataBase = new LiteDatabase(DependencyService.Get<IPathDataBase>().FilePath("CarCardsDb.db"));
        }

        public void Add()
        {

        }
    }
}
