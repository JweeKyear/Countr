
using System;
using System.Drawing;

using Foundation;
using UIKit;
using MvvmCross.Platforms.Ios.Views;
using Countr.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace Countr.iOS.Views
{
    [MvxFromStoryboard]
    public partial class CountersView : MvxTableViewController
    {
        public CountersView(IntPtr handle) : base(handle)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();



            // Release any cached data, images, etc that aren't in use.
        }

        #region View lifecycle

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new CountersTableViewSource(TableView);
            TableView.Source = source;

            var set = this.CreateBindingSet<CountersView, CountersViewModel>();
            var button = new UIBarButtonItem(UIBarButtonSystemItem.Add);
            NavigationItem.SetRightBarButtonItem(button, false);

            set.Bind(source).To(vm => vm.Counters);
            set.Bind(button).To(vm => vm.ShowAddNewCounterCommand);
            set.Apply();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        #endregion
    }
}