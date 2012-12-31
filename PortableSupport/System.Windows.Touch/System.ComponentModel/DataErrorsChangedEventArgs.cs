#region Copyright

// <copyright file="DataErrorsChangedEventArgs.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
//  
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

namespace System.ComponentModel
// ReSharper restore CheckNamespace
{
    public sealed class DataErrorsChangedEventArgs : EventArgs
    {
        private readonly string _propertyName;

        public DataErrorsChangedEventArgs(string propertyName)
        {
            _propertyName = propertyName;
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }
    }
}