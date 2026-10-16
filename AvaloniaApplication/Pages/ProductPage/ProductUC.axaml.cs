using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AvaloniaApplication.Pages.ProductPage;

public partial class ProductUC : UserControl
{
    public ProductUC()
    {
        InitializeComponent();
        LoadData();
    }

    private void RemoveFromList_Click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void AddToList_Click(object? sender, RoutedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    private void LoadData()
    {
        ItemsGrid.ItemsSource = App.DbContext.Products.ToList();
    }
}