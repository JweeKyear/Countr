
using System;
using System.Drawing;

using Foundation;
using UIKit;
using MvvmCross.Platforms.Ios.Views;
using Countr.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace Countr.iOS.Views
{
    public partial class CounterView : MvxViewController
    {
        public CounterView(IntPtr handle) : base(handle)
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

            var button = new UIBarButtonItem(UIBarButtonSystemItem.Done);
            NavigationItem.SetRightBarButtonItem(button, false);

            var set = this.CreateBindingSet<CounterView, CounterViewModel>();
            set.Bind(CounterName).To(vm => vm.Name);
            set.Bind(button).To(vm => vm.SaveCommand);
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