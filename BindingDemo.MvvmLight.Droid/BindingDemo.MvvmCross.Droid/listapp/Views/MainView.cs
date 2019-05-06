using System;
using System.Collections.Generic;
using BindingDemo.MvvmCross.Core;
using BindingDemo.MvvmCross.Core.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;
using MvvmCross.Platforms.Ios.Views;
using UIKit;

namespace listapp.Views
{
    public partial class MainView : MvxTableViewController<MainViewModel>
    {
        public MainView() : base("MainView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ViewModel.StartCollectionChangesCommand.Execute(null);
            var source = new TableSource(TableView);

            this.AddBindings(new Dictionary<object, string>
            {
                {source, "ItemsSource Elements"}
            });

            TableView.Source = source;
            TableView.RowHeight = 60;
            TableView.ReloadData();
        }
    }


    public class TableSource : MvxTableViewSource
    {
        private static readonly NSString MyCellIdentifier = new NSString("MyCell");

        public TableSource(UITableView tableView)
            : base(tableView)
        {
            tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
            tableView.RegisterNibForCellReuse(UINib.FromName("MyCell", NSBundle.MainBundle),
                                              MyCellIdentifier);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath,
                                                              object item)
        {
            NSString cellIdentifier;
            if (item is CollectionElement)
            {
                cellIdentifier = MyCellIdentifier;
            }
            else
            {
                throw new ArgumentException("Unknown type of cell" + item.GetType().Name);
            }

            return (UITableViewCell)TableView.DequeueReusableCell(cellIdentifier, indexPath);
        }
    }
}
