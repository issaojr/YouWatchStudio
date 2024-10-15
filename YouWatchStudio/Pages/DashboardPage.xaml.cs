using Microsoft.Maui.Controls;

namespace YouWatchStudio.Pages
{
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
        }

        private async void OnUploadClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UploadPage());
        }

        private async void OnAnalyticsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MetricsPage());
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync(); // Voltar para a tela de login
        }
    }
}
