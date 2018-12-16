using System;

namespace BindingDemo.NaiveBinding
{
    class Program
    {
        private static View _view;

        static void Main(string[] args)
        {
            _view = new View(new ViewModel());
            _view.Start();
            Console.ReadLine();
        }
    }
}
