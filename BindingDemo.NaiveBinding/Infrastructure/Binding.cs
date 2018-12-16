using System;

namespace BindingDemo.NaiveBinding.Infrastructure
{
    public abstract class Binding : IDisposable
    {
        public abstract void Dispose();
    }
}
