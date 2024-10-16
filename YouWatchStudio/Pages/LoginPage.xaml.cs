using System;
using Microsoft.Maui.Controls;
using YouWatchStudio.Services;  // Importar o servi�o para chamar a API

namespace YouWatchStudio.Pages
{
    public partial class LoginPage : ContentPage
    {
        private readonly ApiService _apiService;  // Inst�ncia do ApiService

        public LoginPage()
        {
            InitializeComponent();
            _apiService = new ApiService();  // Inicializar o ApiService
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Valida��o de campos vazios
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Erro", "Por favor, preencha todos os campos.", "OK");
                return;
            }

            // Autentica��o com a API
            var response = await _apiService.Login(email, password);

            if (response.IsSuccessStatusCode)
            {
                // Obter o token retornado
                var token = await response.Content.ReadAsStringAsync();

                // Setar o token no ApiService para autentica��o nas pr�ximas requisi��es
                _apiService.SetAuthToken(token);

                // Redirecionar para a DashboardPage ap�s um login bem-sucedido
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
