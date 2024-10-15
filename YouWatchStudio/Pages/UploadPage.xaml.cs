using Microsoft.Maui.Controls;
using System;

namespace YouWatchStudio.Pages
{
    public partial class UploadPage : ContentPage
    {
        public UploadPage()
        {
            InitializeComponent();
        }

        private void OnChooseFileClicked(object sender, EventArgs e)
        {
            // Simula escolher um arquivo - implementações mais avançadas podem utilizar um file picker
            SelectedFileLabel.Text = "ArquivoSelecionado.mp4";
        }

        private void OnUploadClicked(object sender, EventArgs e)
        {
            DisplayAlert("Sucesso", "Arquivo enviado com sucesso!", "OK");
        }
    }
}
