using HotelManger.DbContexts;
using HotelManger.Models;
using HotelManger.Services;
using HotelManger.Services.ReservationConflictValidators;
using HotelManger.Services.ReservationCreators;
using HotelManger.Services.ReservationProviders;
using HotelManger.Stores;
using HotelManger.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;

namespace HotelManger
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Data Source = reservoom.db";
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                services.AddSingleton(new ReservoomDbContextFactory(CONNECTION_STRING));
                services.AddSingleton<IReservationProvider, DatabaseReservationProvider>();
                services.AddSingleton<IReservationCreator, DatabaseReservationCreator>();
                services.AddSingleton<IReservationConflictValidator, DatabaseReservationConflictValidator>();

                services.AddTransient<ReservationBook>();
                services.AddSingleton((s) => new Hotel("Andre", s.GetRequiredService<ReservationBook>()));

                services.AddSingleton((s) => CreateReservationListingViewModel(s));
                services.AddTransient<Func<ReservationListingViewModel>>((s) => () => s.GetRequiredService<ReservationListingViewModel>());
                services.AddSingleton<MyNavigationService<ReservationListingViewModel>>();

                services.AddSingleton<MakeReservationViewModel>();
                services.AddTransient<Func<MakeReservationViewModel>>((s) => () => s.GetRequiredService<MakeReservationViewModel>());
                services.AddSingleton<MyNavigationService<MakeReservationViewModel>>();

                services.AddSingleton<HotelStore>();
                services.AddSingleton<NavigationStore>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            }).Build();
        }

        private ReservationListingViewModel CreateReservationListingViewModel(IServiceProvider services)
        {
            return ReservationListingViewModel.LoadViewModel(
                services.GetRequiredService<HotelStore>(),
                services.GetRequiredService<MyNavigationService<MakeReservationViewModel>>());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();

            ReservoomDbContextFactory reservoomDbContextFactory = _host.Services.GetRequiredService<ReservoomDbContextFactory>();
            using (ReservoomDbContext dbContext = reservoomDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }

            MyNavigationService<ReservationListingViewModel> myNavigationService = _host.Services.GetRequiredService<MyNavigationService<ReservationListingViewModel>>();
            myNavigationService.Navigate();

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();//make free ungovernable resources

            base.OnExit(e);
        }
    }
}
