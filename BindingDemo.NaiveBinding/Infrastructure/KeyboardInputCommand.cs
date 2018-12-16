using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BindingDemo.NaiveBinding.Infrastructure
{
    class KeyboardInputCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Console.WriteLine("KeyboardInputCommand was executed. Voila!");
        }
    }
}
