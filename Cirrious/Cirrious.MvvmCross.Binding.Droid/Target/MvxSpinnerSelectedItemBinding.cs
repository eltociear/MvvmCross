#region Copyright

// <copyright file="MvxSpinnerSelectedItemBinding.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
//  
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using System;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.Interfaces;
using Cirrious.MvvmCross.Interfaces.Platform.Diagnostics;

namespace Cirrious.MvvmCross.Binding.Droid.Target
{
    public class MvxSpinnerSelectedItemBinding : MvxBaseAndroidTargetBinding
    {
        private readonly MvxBindableSpinner _spinner;
        private object _currentValue;

        public MvxSpinnerSelectedItemBinding(MvxBindableSpinner spinner)
        {
            _spinner = spinner;
            _spinner.ItemSelected += _spinner_ItemSelected;
        }

        private void _spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var container = (_spinner.SelectedItem as MvxJavaContainer);
            if (container == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Missing MvxJavaContainer in MvxSpinnerSelectedItemBinding");
                return;
            }
            var newValue = container.Object;
            if (!newValue.Equals(_currentValue))
            {
                _currentValue = newValue;
                FireValueChanged(newValue);
            }
        }

        public override void SetValue(object value)
        {
            if (!value.Equals(_currentValue))
            {
                var index = _spinner.Adapter.GetPosition(value);
                if (index < 0)
                {
                    MvxBindingTrace.Trace(MvxTraceLevel.Warning, "Value not found for spinner {0}", value.ToString());
                    return;
                }
                _currentValue = value;
                _spinner.SetSelection(index);
            }
        }

        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.TwoWay; }
        }

        public override Type TargetType
        {
            get { return typeof (object); }
        }

        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                _spinner.ItemSelected -= _spinner_ItemSelected;
            }
            base.Dispose(isDisposing);
        }
    }
}