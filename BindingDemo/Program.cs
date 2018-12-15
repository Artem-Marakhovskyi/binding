using System;
using BindingDemo.BareBinding;

namespace BindingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = new View(new Model());
            
            Console.ReadLine();
        }
    }
}
