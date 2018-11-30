using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MvvmCross.Platforms.Ios.Binding.Views;
using Countr.Core.ViewModels;

namespace Countr.iOS.Views
{
    class CountersTableViewSource : MvxTableViewSource
    {
        public CountersTableViewSource(UITableView tableView) : base(tableView)
        {

        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return (CounterTableViewCell)tableView.DequeueReusableCell("CounterCell");
        }

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
            var counter = (CounterViewModel)GetItemAt(indexPath);
            counter.DeleteCommand.Execute(null);
        }
    }
}