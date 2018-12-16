using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace BindingDemo.NaiveBinding.Infrastructure
{
    class PropertyBinding<TSource, TTarget, TValue> : Binding
        where TSource : INotifyPropertyChanged
    {
        private TSource _sourceObject;
        private TTarget _targetObject;
        private PropertyInfo _sourceProperty;
        private PropertyInfo _targetProperty;

        public PropertyBinding(
            TSource sourceObject,
            TTarget targetObject,
            Expression<Func<TValue>> sourceMemberExpression,
            Expression<Func<TValue>> targetMemberExpression)
        {
            _sourceObject = sourceObject;
            _targetObject = targetObject;
            _sourceProperty = GetProperty(sourceObject, sourceMemberExpression);
            _targetProperty = GetProperty(targetObject, targetMemberExpression);

            SubscribeToPropertyChanged();
            UpdateFromSource();
        }

        public override void Dispose()
        {
            _sourceObject.PropertyChanged -= PropertyChanged;
        }

        private void SubscribeToPropertyChanged()
        {
            _sourceObject.PropertyChanged += PropertyChanged;
        }

        private void UpdateFromSource()
        {
            _targetProperty.SetValue(
                _targetObject,
                _sourceProperty.GetValue(
                    _sourceObject));
        }

        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _sourceProperty.Name)
            {
                UpdateFromSource();
            }
        }

        private PropertyInfo GetProperty<T>(
            T sourceObject,
            Expression<Func<TValue>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            var propertyName = memberExpression.Member.Name;

            return typeof(T).GetProperty(
                propertyName,
                BindingFlags.Public | BindingFlags.Instance);
        }
    }
}
