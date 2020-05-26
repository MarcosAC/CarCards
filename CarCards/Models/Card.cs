﻿using Xamarin.Forms;

namespace CarCards.Models
{
    public class Card
    {
        public string Marca { get; set; }
        public string NomeCarro { get; set; }
        public string Ano { get; set; }
        public string Velocidade { get; set; }
        public string Aceleracao { get; set; }
        public string Potencia { get; set; }
        public string Cilindradas { get; set; }
        public string Motor { get; set; }
        public ImageSource Foto { get; set; }
        public string CaminhoFoto { get; set; }
        //public string ImagemMarca { get; set; }
    }
}
