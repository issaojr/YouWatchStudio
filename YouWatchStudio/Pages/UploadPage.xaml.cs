using Microsoft.Maui.Controls;
using System;
using YouWatchStudio.Services;  // Importar o serviço para chamar a API
using Microsoft.Maui.Storage;  // Necessário para o FilePicker

namespace YouWatchStudio.Pages
{
    public partial class UploadPage : ContentPage
    {
        private readonly ApiService _apiService;  // Instância do ApiService
        private FileResult _selectedFile;  // Representa o arquivo escolhido

        public UploadPage()
        {
            InitializeComponent();
            _apiService = new ApiService();  // Inicializar o ApiService
        }

        private async void OnChooseFileClicked(object sender, EventArgs e)
        {
            try
            {
                // Utiliza um picker para selecionar um arquivo
                _selectedFile = await FilePicker.PickAsync(new PickOptions
                {
                    PickerTitle = "Escolha um arquivo de vídeo",
                    FileTypes = FilePickerFileType.Videos // Filtra apenas arquivos de vídeo
                });

                if (_selectedFile != null)
                {
                    SelectedFileLabel.Text = _selectedFile.FileName;  // Atualiza o rótulo com o nome do arquivo selecionado
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao selecionar arquivo: {ex.Message}", "OK");
            }
        }

        private async void OnUploadClicked(object sender, EventArgs e)
        {
            if (_selectedFile == null)
            {
                await DisplayAlert("Erro", "Por favor, selecione um arquivo primeiro.", "OK");
                return;
            }

            try
            {
                // Converte o arquivo selecionado em stream para envio
                using var stream = await _selectedFile.OpenReadAsync();

                // Chama o ApiService para enviar o arquivo para a API
                var response = await _apiService.UploadFileAsync(stream, _selectedFile.FileName);

                if (response.IsSuccessStatusCode)
                {
                    await DisplayAlert("Sucesso", "Arquivo enviado com sucesso!", "OK");
                }
                else
                {
                    await DisplayAlert("Erro", "Falha ao enviar o arquivo.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Erro ao enviar arquivo: {ex.Message}", "OK");
            }
        }
    }
}
