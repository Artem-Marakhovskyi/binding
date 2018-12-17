using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace BindingDemo.MvvmCross.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private const string ElementContentConst = "Element {0}, changes {1}";

        private string _text;
        private MvxCommand _startElementsChangesCommand;
        private MvxCommand _clearCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text { get; set; }

        public ObservableCollection<CollectionElement> Elements { get; private set; }

        public MvxCommand StartCollectionChangesCommand
            => _startElementsChangesCommand ??
                (_startElementsChangesCommand = new MvxCommand(StartCollectionChanges));

        public MvxCommand ClearCommand
            => _clearCommand ??
                (_clearCommand = new MvxCommand(() => Text = string.Empty));

        public MainViewModel()
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
                    Elements.RemoveAt(idx);
                    Elements.Insert(idx, element);
                }
            }
        }
    }
}
