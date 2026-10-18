using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaApplication.ViewModels;

public sealed class AsyncCommand : ICommand
{
    private readonly Func<Task> _execute;
    private readonly Func<bool>? _canExecute;
    private bool _isExecuting;

    public AsyncCommand(
        Func<Task> execute,
        Func<bool>? canExecute = null)
    {
        _execute = execute
                   ?? throw new ArgumentNullException(nameof(execute));

        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) =>
        !_isExecuting && (_canExecute?.Invoke() ?? true);

    public async void Execute(object? parameter)
    {
        if (!CanExecute(parameter))
            return;

        _isExecuting = true;
        NotifyCanExecuteChanged();

        try
        {
            await _execute();
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Command failed: {exception}");
        }
        finally
        {
            _isExecuting = false;
            NotifyCanExecuteChanged();
        }
    }

    public void NotifyCanExecuteChanged() =>
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}