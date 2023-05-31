using System.IO;
using System.Windows;
using HotelReservation.Core.Helpers;
using HotelReservation.Core.Repository;
using HotelReservation.Core.WPFInterfaces;
using HotelReservationWPF.View;
using HotelReservationWPF.View.Pages;
using HotelReservationWPF.ViewModel; 
using HotelReservationWPF.ViewModel.Interfaces;
using HotelReservationWPF.ViewModel.Page;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HotelReservationWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Properties

        public static IHost? AppHost { get; private set; }

        public IConfiguration Configuration { get; private set; }

        #endregion

        #region Constructor

        public App()
        {
            AppHost = Host.CreateDefaultBuilder().ConfigureServices((hostContext, services) =>
            {
                services.ConfigureDatabase();
                services.ConfigureServices();
                services.ConfigureRepository();
                PreparePages(services);
                PrepareViewModels(services);
                PrepareViews(services);
                PrepareApplication(services);
            }).Build();
        }

        #endregion

        #region Methods

        protected async override void OnStartup(StartupEventArgs e)
        {
            await AppHost.StopAsync();
            IHotelReservationApp app = AppHost.Services.GetRequiredService<IHotelReservationApp>();
            Current.MainWindow = app.MainWindow as Window;
            app.Run();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }


        private void PrepareApplication(IServiceCollection services)
        {
            services.AddSingleton<Application>((o) => { return this; });
            services.AddSingleton<INavigation, NavigationViewModel>((o) => {
                return new NavigationViewModel() { AppHost = AppHost };
            });
            services.AddSingleton<IHotelReservationApp,HotelReservationApp>();
        }

        private void PrepareViews(IServiceCollection services)
        {
            services.AddTransient<IMainWindow, MainWindow>();
            services.AddTransient<DashBoardPageView>();
            //services.AddSingleton<ILoginWindow, LoginView>();
            //services.AddSingleton<IRegisterWindow, RegisterView>();
        }

        private void PrepareViewModels(IServiceCollection services)
        {
            
            //services.AddSingleton<MainViewModel>();
            //services.AddSingleton<LoginViewModel>();
            //services.AddSingleton<RegisterViewModel>();
        }


        private void PreparePages(IServiceCollection services)
        {
            services.AddTransient<DashBoardPageViewModel>();
            //services.AddTransient<ProductsPage>();
        }

        private void AddCOnfiguration(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();
            services.AddSingleton(Configuration);
        }

        #endregion
    }
}
