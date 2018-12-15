﻿using System;

namespace BindingDemo.BareBinding.Infrastructure
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            Console.WriteLine("Command executed, enter pressed. Voila!");
        }
    }
}