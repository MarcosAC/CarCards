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

        readonly Card card = new Card
        {

        };

        private DelegateCommand _addCard;

        public DelegateCommand AddCard => _addCard ?? (new DelegateCommand(() => ExecuteAddCard(card)));

        private void ExecuteAddCard(Card card)
        {
            DataCarCards.Add(card);
        }
    }
}
