using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Domain.Models;
using Infastructure.Repositories;
using AvaloniaApplication.ViewModels;

namespace AvaloniaApplication.Pages.ProductPage;

public partial class ProductUC : UserControl
{
    private readonly ProductListViewModel _viewModel;

    public ProductUC()
    {
        InitializeComponent();

        _viewModel = new ProductListViewModel(
            new ProductRepository(App.DbContext));

        DataContext = _viewModel;
        Loaded += OnLoaded;
    }

    public Task LoadDataAsync() =>
        _viewModel.LoadProductsAsync();

    public void FilterData(string searchText) =>
        _viewModel.SetSearchFilter(searchText);

    private async void OnLoaded(
        object? sender,
        RoutedEventArgs e)
    {
        await LoadDataAsync();
    }

    private async void OnBoughtClick(
        object? sender,
        RoutedEventArgs e)
    {
        if (sender is not CheckBox
            {
                DataContext: Product product
            })
            return;

        await _viewModel.SaveBoughtStateAsync(product);
    }

    private void AddToList_Click(
        object? sender,
        RoutedEventArgs e)
    {
        // Навигация к списку покупок реализуется отдельно.
    }

    private async void RemoveFromList_Click(
        object? sender,
        RoutedEventArgs e)
    {
        if (sender is not Button
            {
                DataContext: Product product
            })
            return;

        await _viewModel.DeleteProductAsync(product);
    }
}