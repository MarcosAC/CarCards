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
            //InitializeComponent();

            //MainPage = new NavigationPage(new PaginaPrincipalView())
            //{
            //    BarBackgroundColor = Color.White
            //};
        }
        protected override async void OnInitialized()
        {
            InitializeComponent();

            var result = await NavigationService.NavigateAsync("/NavigationPage/PrincipalPage");

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<PrincipalPage, PrincipalPageViewModel>();
            //containerRegistry.RegisterForNavigation<ViewA, ViewAViewModel>();
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
