using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Domain.Models;
using Infastructure.DbContext;
using Infastructure.Repositories;

namespace AvaloniaApplication.Pages;

public partial class Header : UserControl
{
    public Header()
    {
        InitializeComponent();
    }
    
    private async void OnAddClick(object? sender, RoutedEventArgs e)
    {
        var repository = new ProductRepository(new ContextDb());
        var result = Product.Create(ProductNameInput.Text);
        
        if (result.product is null)
        {
            Console.WriteLine(result.error);
            return;
        }
        
        await repository.CreateProductAsync(result.product);
        ProductNameInput.Clear();
    }
}