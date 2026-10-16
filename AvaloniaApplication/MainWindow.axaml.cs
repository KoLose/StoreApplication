using Avalonia.Controls;

namespace AvaloniaApplication;

public partial class MainWindow : Window
{
    private ProductPage.ProductUC _productPage;

    public MainWindow()
    {
        InitializeComponent();

        HeaderContent.Content = new Pages.Header();

        _productPage = new Pages.ProductPage.ProductUC();
        MainContent.Content = _productPage;
    }

    public void ApplySearchFilter(string searchText)
    {
        _productPage.FilterData(searchText);
    }

    public void RefreshProductList()
    {
        _productPage.LoadData();
    }
}