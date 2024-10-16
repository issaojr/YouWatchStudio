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
            Title = "Gerenciamento de Conteúdo";

            // Layout de stack para acomodar os botões de gerenciamento
            var stackLayout = new StackLayout
            {
                Padding = new Thickness(20),
                Spacing = 15
            };

            // Botão de Upload de Conteúdo
            var uploadButton = new Button
            {
                Text = "Upload de Conteúdo",
                VerticalOptions = LayoutOptions.Center
            };
            uploadButton.Clicked += OnUploadClicked;

            // Botão de Editar Conteúdo
            var editButton = new Button
            {
                Text = "Editar Conteúdo",
                VerticalOptions = LayoutOptions.Center
            };
            editButton.Clicked += OnEditContentClicked;

            // Botão de Remover Conteúdo
            var deleteButton = new Button
            {
                Text = "Remover Conteúdo",
                VerticalOptions = LayoutOptions.Center
            };
            deleteButton.Clicked += OnDeleteContentClicked;

            // Adicionando os botões ao layout
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
            // Aqui seria a lógica para editar o conteúdo
            await DisplayAlert("Em Desenvolvimento", "Funcionalidade de edição de conteúdo ainda em desenvolvimento.", "OK");
        }

        private async void OnDeleteContentClicked(object sender, EventArgs e)
        {
            // Aqui seria a lógica para deletar o conteúdo
            await DisplayAlert("Em Desenvolvimento", "Funcionalidade de remoção de conteúdo ainda em desenvolvimento.", "OK");
        }
    }
}
