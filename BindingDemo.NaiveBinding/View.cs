using BindingDemo.NaiveBinding.Infrastructure;
using System;
using System.Collections.Generic;

namespace BindingDemo.NaiveBinding
{
    class View : IDisposable
    {
        private const string OutputFormat = "{0}, {1} \n Press button:";

        private readonly ViewModel _viewModel;

        private readonly IList<IDisposable> _bindings = new List<IDisposable>();

        private DateTime _time;
        private int _percentage;

        public event EventHandler EnterPressed = (obj, ea) => { };
        public event EventHandler KeyPressed = (obj, ea) => { };

        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                Out();
            }
        }

        public int Percentage
        {
            get => _percentage;
            set
            {
                _percentage = value;
                Out();
            }
        }

        public View(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Start()
        {
            _bindings.Add(
                new PropertyBinding<ViewModel, View, DateTime>(
                    _viewModel,
                    this,
                    () => _viewModel.Time,
                    () => Time));

            _bindings.Add(
                new PropertyBinding<ViewModel, View, int>(
                    _viewModel,
                    this,
                    () => _viewModel.Percentage,
                    () => Percentage));

            _bindings.Add(
                new CommandBinding<View>(
                    _viewModel.EnterCommand,
                    this,
                    nameof(EnterPressed)));

            _bindings.Add(
                new CommandBinding<View>(
                    _viewModel.KeyboardInputCommand,
                    this,
                    nameof(KeyPressed)));

            ReadInput();
            Dispose();
        }
        
        public void Dispose()
        {
            foreach (var binding in _bindings)
            {
                binding.Dispose();
            }
        }

        private void ReadInput()
        {
            var keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                EnterPressed(this, EventArgs.Empty);
            }
            else
            {
                KeyPressed(this, EventArgs.Empty);
            }

        }

        private void Out()
        {
            Console.Clear();

            Console.WriteLine(
                string.Format(
                    OutputFormat,
                    Time.ToString(),
                    new string('.', Percentage)));
        }
    }
}
