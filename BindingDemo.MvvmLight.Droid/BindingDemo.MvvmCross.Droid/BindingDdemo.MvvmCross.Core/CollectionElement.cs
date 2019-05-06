using System;
using System.ComponentModel;

namespace BindingDemo.MvvmCross.Core
{
    public class CollectionElement : INotifyPropertyChanged
    {
        public int Index { get; set; }
        public int ChangesCount { get; set; }

        public string Name => $"Element {Index}, changes: {ChangesCount}";

        public event PropertyChangedEventHandler PropertyChanged;

        public string ResText => Resources.AddButton; 

        public CollectionElement(int index, int changesCount)
        {
            Index = index;
            ChangesCount = changesCount;
        }
    }
}
