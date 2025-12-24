using Locker_KIOSK.Services;
using Locker_KIOSK.ViewModels;
using System;
using System.Net.Http;
using System.Windows;

namespace Locker_KIOSK
{
    public partial class App : Application
    {
        public static ApiService ApiService { get; private set; } = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var baseUrl = AppConfig.Configuration["ApiSettings:BaseUrl"];
            var apiKey = AppConfig.Configuration["ApiSettings:Apikey"];
            var version = AppConfig.Configuration["ApiSettings:Version"];


            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl +$"/api/v{version}/Locker/"),
                Timeout = TimeSpan.FromSeconds(30)
            };

            httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);

            ApiService = new ApiService(httpClient);

            MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(ApiService)
            };
            MainWindow.Show();
        }
    }

}
