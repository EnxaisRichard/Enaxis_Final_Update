using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DevonApp3.Views;
using DevonApp3.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DevonApp3
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<RequestAccess, RequestAccessViewModel>();
            Container.RegisterTypeForNavigation<Summary, SummaryViewModel>();
            Container.RegisterTypeForNavigation<Contacts, ContactsViewModel>();
            Container.RegisterTypeForNavigation<Analytics, AnalyticsViewModel>();
            Container.RegisterTypeForNavigation<Alert, AlertViewModel>();
            
        }
    }
}
