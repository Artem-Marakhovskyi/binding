using System;
namespace BindingDemo.BareBinding.Infrastructure
{
    public interface ICommand
    {
        event EventHandler CanExecuteChanged;

        bool CanExecute(object parameter);

        void Execute(object parameter);
    }
}
