using CarCards.ViewModels;
using CarCards.Views;
using Prism.Ioc;
using Prism.DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App
    {
        public App()
        {
        }
        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/NavigationPage/PrincipalPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<PrincipalPage, PrincipalViewModel>();
            containerRegistry.RegisterForNavigation<AdicionarCardPage>();
            //containerRegistry.RegisterForNavigation<ViewB, ViewBViewModel>();
            //containerRegistry.RegisterForNavigation<ViewC, ViewCViewModel>();
        }
    }

    //protected override void OnStart()
    //{
    //}

    //protected override void OnSleep()
    //{
    //}

    //protected override void OnResume()
    //{
    //}
}
