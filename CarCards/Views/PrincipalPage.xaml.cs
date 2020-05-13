using CarCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarCards.Views
{    
    public partial class PrincipalPage : ContentPage
    {
        public PrincipalPage()
        {
            InitializeComponent();

            BindingContext = new PrincipalPageViewModel();            
        }
    }
}