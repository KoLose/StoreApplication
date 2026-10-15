using Avalonia.Controls;

namespace AvaloniaApplication;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        HeaderContent.Content = new Pages.Header();
        MainContent.Content = new Pages.ProductPage.ProductUC();
    }
}