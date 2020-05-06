using CarCards.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarCards.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        public PaginaPrincipal()
        {
            InitializeComponent();

            BindingContext = new BaseViewModel();
        }
    }
}