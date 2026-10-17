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

    private void LoadData()
    {
        ItemsGrid.ItemsSource = App.DbContext.Products.ToList();
    }
}