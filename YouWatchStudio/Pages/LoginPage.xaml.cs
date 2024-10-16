using System;
using Microsoft.Maui.Controls;
using YouWatchStudio.Services;  // Importar o serviço para chamar a API

namespace YouWatchStudio.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly ApiService _apiService;  // Instância do ApiService

        public LoginPage()
        {
            InitializeComponent();
            _apiService = new ApiService();  // Inicializar o ApiService
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Validação de campos vazios
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            // Autenticação com a API
            var response = await _apiService.Login(email, password);

            if (response.IsSuccessStatusCode)
            {
                // Obter o token retornado
                var token = await response.Content.ReadAsStringAsync();

                // Setar o token no ApiService para autenticação nas próximas requisições
                _apiService.SetAuthToken(token);

                // Redirecionar para a DashboardPage após um login bem-sucedido
                await Shell.Current.GoToAsync("//DashboardPage");
            }
            else
            {
                // Mensagem de erro
                await DisplayAlert("Erro", "Email ou senha incorretos.", "OK");
            }
        }
    }
}
