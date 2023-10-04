using System.Windows.Input;

namespace Maui.Feed.App.Abstractions.Models
{
    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);

        void RaiseCanExecuteChanged();
    }

    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();

        void RaiseCanExecuteChanged();
    }
}
