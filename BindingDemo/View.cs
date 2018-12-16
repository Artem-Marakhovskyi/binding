using System;
using System.Threading.Tasks;
using BindingDemo.BareBinding.Infrastructure;

namespace BindingDemo.BareBinding
{
    public class View
    {
        private const string OutputFormat = "{0}, {1} \n Press ENTER:";

        private readonly ViewModel _viewModel;

        public View(ViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public void Start()
        {
            _viewModel.PropertyChanged += ViewModelPropertyChanged;
            ReadInput();
            _viewModel.PropertyChanged -= ViewModelPropertyChanged;
        }

        private void ReadInput()
        {
            var keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                _viewModel.EnterCommand.Execute(null);
            }
            else
            {
                _viewModel.KeyboardInputCommand.Execute(null);
            }
        }

        private void ViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_viewModel.Time):
                    {
                        Out();
                        break;
                    }
                case nameof(_viewModel.Percentage):
                    {
                        Out();
                        break;
                    }
            }
        }

        private void Out()
        {
            Console.Clear();

            Console.WriteLine(
                string.Format(
                    OutputFormat,
                    _viewModel.Time.ToString(),
                    new string('.', _viewModel.Percentage)));
        }
    }
}
