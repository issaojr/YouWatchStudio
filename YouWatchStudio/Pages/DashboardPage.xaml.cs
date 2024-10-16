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
            await Shell.Current.GoToAsync("//UploadPage");
        }

        private async void OnMetricsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//MetricsPage");
        }

        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            // Voltar para a tela de login
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
