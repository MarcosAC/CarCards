﻿using CarCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarCards.Views
{    
    public partial class PaginaPrincipalView : ContentPage
    {
        public PaginaPrincipalView()
        {
            InitializeComponent();

            BindingContext = new PaginaPrincipalViewModel();            
        }
    }
}