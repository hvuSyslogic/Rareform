﻿using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace FlagLib.Patterns
{
    /// <summary>
    /// Provides an abstract and generic view model base class, <para />
    /// which implements the <see cref="INotifyPropertyChanged"/> interface
    /// </summary>
    /// <typeparam name="T">Type of the concrete view model</typeparam>
    public abstract class ViewModelBase<T> : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when a property has changed.
        /// </summary>
        /// <typeparam name="TValue">The type of the property.</typeparam>
        /// <param name="propertySelector">The property selector.</param>
        protected void OnPropertyChanged<TValue>(Expression<Func<T, TValue>> propertySelector)
        {
            if (PropertyChanged != null)
            {
                MemberExpression memberExpression = propertySelector.Body as MemberExpression;

                if (memberExpression != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(memberExpression.Member.Name));
                }
            }
        }
    }
}