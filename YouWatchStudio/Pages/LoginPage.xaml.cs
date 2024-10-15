using System;
using Microsoft.Maui.Controls;

namespace YouWatchStudio.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            // Validação simples apenas para prototipagem
            if (email == "admin@youwatch.com" && password == "password123")
            {
                // Redireciona para a página principal após um login bem-sucedido
                await Shell.Current.GoToAsync("//dashboard");

            }
            else
            {
                // Mensagem de erro
                await DisplayAlert("Erro", "Email ou senha incorretos.", "OK");
            }
        }
    }
}
