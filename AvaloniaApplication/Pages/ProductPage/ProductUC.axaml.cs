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

    public void LoadData()
    {
        ItemsGrid.ItemsSource = App.DbContext.Products.ToList();
    }

    public void FilterData(string searchText)
    {
        if (string.IsNullOrWhiteSpace(searchText))
        {
            LoadData();
            return;
        }

        var filtered = App.DbContext.Products
            .Where(p => p.Name.ToLower().Contains(searchText.ToLower()))
            .ToList();

        ItemsGrid.ItemsSource = filtered;
    }
}