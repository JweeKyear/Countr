﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.V7.Widget;
using Countr.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace Countr.Droid.Views
{
    [Activity(Label = "Add a new counter")]
    public class CounterView : MvxAppCompatActivity<CounterViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.counter_view);

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    ViewModel.CancelCommand.Execute(null);
                    return true;
                default:
                return base.OnOptionsItemSelected(item);

                case Resource.Id.action_save_counter:
                    ViewModel.SaveCommand.Execute(null);
                    return true;
            }
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            toolbar.InflateMenu(Resource.Menu.new_counter_menu);
            return true;
        }
    }
}