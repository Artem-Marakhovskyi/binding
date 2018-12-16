using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;

namespace BindingDemo.MvvmLight.Core
{
    public class ViewModel : INotifyPropertyChanged
    {
        private const string ElementContentConst = "Element {0}, changes {1}";

        private string _text;
        private RelayCommand _startElementsChangesCommand;
        private RelayCommand _clearCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text { get; set; }

        // Fody.PropertyChanged
        //public string Text
        //{
        //    get => _text;
        //    set
        //    {
        //        _text = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
        //    }
        //}

        public ObservableCollection<CollectionElement> Elements { get; private set; }

        public RelayCommand StartCollectionChangesCommand
            => _startElementsChangesCommand ??
                (_startElementsChangesCommand = new RelayCommand(StartCollectionChanges));

        public RelayCommand ClearCommand
            => _clearCommand ??
                (_clearCommand = new RelayCommand(() => Text = string.Empty));

        public ViewModel()
        {
            Elements = new ObservableCollection<CollectionElement>();
        }

        public async void StartCollectionChanges()
        {
            Console.WriteLine("STARTING COLLECTION CHANGES");
            Elements.Clear();
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                await Task.Delay(1000);

                if (random.Next(10) > 7 || Elements.Count == 0)
                {
                    Elements.Add(new CollectionElement(Elements.Count, 0));
                    Console.WriteLine("ELEMENT IS ADDED");
                }
                else
                {
                    Console.WriteLine("ELEMENT IS CHANGED");
                    var idx = random.Next(Elements.Count);
                    var element = Elements[idx];
                    element.ChangesCount++;
                    Elements[idx] = element;
                }
            }
        }
    }
}
