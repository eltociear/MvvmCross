﻿#region Copyright

// <copyright file="IMvxViewModel.cs" company="Cirrious">
// (c) Copyright Cirrious. http://www.cirrious.com
// This source is subject to the Microsoft Public License (Ms-PL)
// Please see license.txt on http://opensource.org/licenses/ms-pl.html
// All other rights reserved.
// </copyright>
//  
// Project Lead - Stuart Lodge, Cirrious. http://www.cirrious.com

#endregion

using Cirrious.MvvmCross.Interfaces.Views;

namespace Cirrious.MvvmCross.Interfaces.ViewModels
{
    public interface IMvxViewModel
        : IMvxViewTracker
    {
        MvxRequestedBy RequestedBy { get; set; }
    }
}