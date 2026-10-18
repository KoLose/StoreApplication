
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Domain.IRepository;
using Domain.Models;

namespace AvaloniaApplication.ViewModels;

public sealed class ProductListViewModel : INotifyPropertyChanged
{
    private readonly IProductRepository _repository;
    private string _searchText = string.Empty;

    public ProductListViewModel(IProductRepository repository)
    {
        _repository = repository
            ?? throw new ArgumentNullException(nameof(repository));

        ClearBoughtCommand = new AsyncCommand(
            ClearBoughtAsync,
            () => BoughtCount > 0);

        Products.CollectionChanged += (_, _) =>
        {
            OnPropertyChanged(nameof(BoughtCount));
            RefreshVisibleProducts();
            ClearBoughtCommand.NotifyCanExecuteChanged();
        };
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    // Полный список товаров
    public ObservableCollection<Product> Products { get; } = new();

    // Список товаров с учётом поиска
    public ObservableCollection<Product> VisibleProducts { get; } = new();

    // Количество купленных товаров
    public int BoughtCount =>
        Products.Count(product => product.IsBought);

    // Команда очистки купленных товаров
    public AsyncCommand ClearBoughtCommand { get; }

    public async Task LoadProductsAsync()
    {
        var products = await _repository.GetAllProductsAsync();

        Products.Clear();

        foreach (var product in products)
            Products.Add(product);
    }

    public void SetSearchFilter(string searchText)
    {
        _searchText = searchText ?? string.Empty;
        RefreshVisibleProducts();
    }

    public async Task SaveBoughtStateAsync(Product product)
    {
        await _repository.UpdateProductAsync(product);

        OnPropertyChanged(nameof(BoughtCount));
        ClearBoughtCommand.NotifyCanExecuteChanged();
    }

    public async Task DeleteProductAsync(Product product)
    {
        await _repository.DeleteProductAsync(product);
        Products.Remove(product);
    }

    private async Task ClearBoughtAsync()
    {
        // Создаём копию, чтобы безопасно удалять элементы из Products
        var boughtProducts = Products
            .Where(product => product.IsBought)
            .ToList();

        foreach (var product in boughtProducts)
        {
            await _repository.DeleteProductAsync(product);
            Products.Remove(product);
        }
    }

    private void RefreshVisibleProducts()
    {
        var filteredProducts = string.IsNullOrWhiteSpace(_searchText)
            ? Products.ToList()
            : Products
                .Where(product => product.Name.Contains(
                    _searchText,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();

        VisibleProducts.Clear();

        foreach (var product in filteredProducts)
            VisibleProducts.Add(product);
    }

    private void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}
