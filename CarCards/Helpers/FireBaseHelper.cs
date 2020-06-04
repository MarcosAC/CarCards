﻿using CarCards.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CarCards.Helpers
{
    public class FireBaseHelper
    {
        private readonly FirebaseClient firebase = new FirebaseClient("https://carcards-d6bc8.firebaseio.com/");

        public async Task AddCard(Card card) => await firebase.Child("Cards").PostAsync<Card>(card);
        //{
        //    await firebase
        //        .Child("Cards")
        //        .PostAsync<Card>(card);
        //}

        public async Task<List<Card>> GetAll()
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
    }
}
