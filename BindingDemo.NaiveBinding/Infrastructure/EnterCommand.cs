using System;
using System.Windows.Input;

namespace BindingDemo.NaiveBinding.Infrastructure
{
    public class EnterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Console.WriteLine("EnterCommand executed, enter pressed. Voila!");
        }
    }
}
