using Microsoft.Maui.Controls;

namespace YouWatchStudio.Pages
{
    public partial class ContentManagementPage : ContentPage
    {
        public ContentManagementPage()
        {
            InitializeComponent();
            CreateUI();
        }

        private void CreateUI()
        {
            Title = "Gerenciamento de Conte�do";

            // Layout de stack para acomodar os bot�es de gerenciamento
            var stackLayout = new StackLayout
            {
                Padding = new Thickness(20),
                Spacing = 15
            };

            // Bot�o de Upload de Conte�do
            var uploadButton = new Button
            {
                Text = "Upload de Conte�do",
                VerticalOptions = LayoutOptions.Center
            };
            uploadButton.Clicked += OnUploadClicked;

            // Bot�o de Editar Conte�do
            var editButton = new Button
            {
                Text = "Editar Conte�do",
                VerticalOptions = LayoutOptions.Center
            };
            editButton.Clicked += OnEditContentClicked;

            // Bot�o de Remover Conte�do
            var deleteButton = new Button
            {
                Text = "Remover Conte�do",
                VerticalOptions = LayoutOptions.Center
            };
            deleteButton.Clicked += OnDeleteContentClicked;

            // Adicionando os bot�es ao layout
            stackLayout.Children.Add(uploadButton);
            stackLayout.Children.Add(editButton);
            stackLayout.Children.Add(deleteButton);

            Content = stackLayout;
        }

        private async void OnUploadClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//UploadPage");
        }

        private async void OnEditContentClicked(object sender, EventArgs e)
        {
            // Aqui seria a l�gica para editar o conte�do
            await DisplayAlert("Em Desenvolvimento", "Funcionalidade de edi��o de conte�do ainda em desenvolvimento.", "OK");
        }

        private async void OnDeleteContentClicked(object sender, EventArgs e)
        {
            // Aqui seria a l�gica para deletar o conte�do
            await DisplayAlert("Em Desenvolvimento", "Funcionalidade de remo��o de conte�do ainda em desenvolvimento.", "OK");
        }
    }
}
