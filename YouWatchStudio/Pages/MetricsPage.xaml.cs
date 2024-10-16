using Microsoft.Maui.Controls;

namespace YouWatchStudio.Pages
{
    public partial class MetricsPage : ContentPage
    {
        // Construtor da página
        public MetricsPage()
        {
            InitializeComponent();
            SetUpMetrics();
        }

        // Método para configurar as métricas simuladas
        private void SetUpMetrics()
        {
            var metricsLayout = new StackLayout
            {
                Padding = 20
            };

            var viewsLabel = new Label
            {
                Text = "Visualizações: 10,000",
                FontSize = 18,
                Margin = new Thickness(0, 10)
            };

            var likesLabel = new Label
            {
                Text = "Curtidas: 1,500",
                FontSize = 18,
                Margin = new Thickness(0, 10)
            };

            var commentsLabel = new Label
            {
                Text = "Comentários: 250",
                FontSize = 18,
                Margin = new Thickness(0, 10)
            };

            metricsLayout.Children.Add(viewsLabel);
            metricsLayout.Children.Add(likesLabel);
            metricsLayout.Children.Add(commentsLabel);

            Content = metricsLayout;
        }
    }
}
