using System;
using System.Threading.Tasks;
using BindingDemo.BareBinding.Infrastructure;

namespace BindingDemo.BareBinding
{
    public class View
    {
        private const string OutputFormat = "{0}, {1} \n Press ENTER:";

        private readonly Model _model;

        public View(Model model)
        {
            _model = model;
            _model.PropertyChanged += ModelPropertyChanged;
            _model.Command.Execute(Console.ReadLine());
            _model.PropertyChanged -= ModelPropertyChanged;
        }

        private void ModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(_model.Time):
                    {
                        Out();
                        break;
                    }
                case nameof(_model.Percentage):
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
                    _model.Time.ToString(),
                    new string('.', _model.Percentage)));
        }
    }
}
