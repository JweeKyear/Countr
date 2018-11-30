using System;

using Foundation;
using UIKit;
using Countr.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Binding.Views;

namespace Countr.iOS.Views
{
    public partial class CounterTableViewCell : MvxTableViewCell
    {
        public CounterTableViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<CounterTableViewCell, CounterViewModel>();

                set.Bind(CounterName).To(vm => vm.Name);
                set.Bind(CounterCount).To(vm => vm.Count);
                set.Bind(IncrementButton).To(vm => vm.IncrementCommand);
                set.Apply();
            }
                );
            // Note: this .ctor should not contain any initialization logic.
        }
    }
}
