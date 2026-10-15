using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Domain.Models;

namespace AvaloniaApplication.Pages;

public partial class Header : UserControl
{
    public Header()
    {
        InitializeComponent();
    }

    private void OnAddClick(object? sender, RoutedEventArgs e)
    {
        var result = Product.Create(ProductNameInput.Text);
        
        ProductNameInput.Clear();
    }
}