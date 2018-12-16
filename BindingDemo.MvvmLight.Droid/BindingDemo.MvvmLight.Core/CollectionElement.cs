using System;
using System.ComponentModel;

namespace BindingDemo.MvvmLight.Core
{
    public class CollectionElement
    {
        public int Index { get; set; }
        public int ChangesCount { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CollectionElement(int index, int changesCount)
        {
            Index = index;
            ChangesCount = changesCount;
        }

        public override string ToString()
        {
            return $"Element {Index}, changes: {ChangesCount}";
        }
    }
}
