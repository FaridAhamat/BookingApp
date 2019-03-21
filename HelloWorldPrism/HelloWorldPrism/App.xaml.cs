using Prism;
using Prism.Ioc;
using HelloWorldPrism.ViewModels;
using HelloWorldPrism.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HelloWorldPrism.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloWorldPrism
{
    public partial class App
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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register services
            containerRegistry.Register<CustomerService>();
            containerRegistry.Register<BookingService>();

            // Register navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<CustomerManagement, CustomerManagementViewModel>();
            containerRegistry.RegisterForNavigation<BookingManagement, BookingManagementViewModel>();
        }
    }
}
