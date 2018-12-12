using System;
namespace BindingDemo.BareBinding
{
    public class View
    {
        private const string OutputFormat = "{0}, {1}";

        private readonly Model _model;

        public View(Model model)
        {
            _model = model;
            _model.PropertyChanged += ModelPropertyChanged;
        }

        private void ModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_model.Time):
                    {
                        Console.Clear();
                        Out();
                        break;
                    }
                case nameof(_model.Percentage):
                    {
                        Console.Clear();
                        Out();
                        break;
                    }
            }
        }

        private void Out()
        {
            Console.WriteLine(
                string.Format(
                    OutputFormat,
                    _model.Time.ToString(),
                    new string('.', _model.Percentage)));
        }
    }
}
