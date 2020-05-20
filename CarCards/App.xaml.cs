using CarCards.ViewModels;
using CarCards.Views;
using Prism.Ioc;
using Prism.DryIoc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;

namespace CarCards
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class App : PrismApplication
    {
        public App()
        {
        }

        public App(IPlatformInitializer platformInitializer) : base(platformInitializer)
        {
        }

        public App(IPlatformInitializer platformInitializer, bool setFormsDependencyResolver) : base(platformInitializer, setFormsDependencyResolver)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<AddCardPage>();
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
