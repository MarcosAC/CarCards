using CarCards.ViewModels;
using CarCards.Views;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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
            containerRegistry.RegisterForNavigation<AddCardPage, AddCardPageViewModel>();
        }
    }
}
