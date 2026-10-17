using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Domain.Models;
using Infastructure.Repositories;

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

    private async void OnBoughtClick(object? sender, RoutedEventArgs e)
    {
        if (sender is not CheckBox { DataContext: Product product })
            return;

        await new ProductRepository(App.DbContext).UpdateProductAsync(product);
    }
    s
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