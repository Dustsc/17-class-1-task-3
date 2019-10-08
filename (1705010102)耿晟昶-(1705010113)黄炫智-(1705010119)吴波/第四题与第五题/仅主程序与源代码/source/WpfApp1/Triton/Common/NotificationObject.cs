using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.Triton.Common
{
    using JetBrains.Annotations;
    using System;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows;

    public class NotificationObject : INotifyPropertyChanged
    {
        [CompilerGenerated]
        private PropertyChangedEventHandler propertyChangedEventHandler_0;

        public event PropertyChangedEventHandler PropertyChanged
        {
            [CompilerGenerated]
            add
            {
                PropertyChangedEventHandler objA = this.propertyChangedEventHandler_0;
                while (true)
                {
                    PropertyChangedEventHandler a = objA;
                    PropertyChangedEventHandler handler3 = (PropertyChangedEventHandler)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChangedEventHandler_0, handler3, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PropertyChangedEventHandler objA = this.propertyChangedEventHandler_0;
                while (true)
                {
                    PropertyChangedEventHandler source = objA;
                    PropertyChangedEventHandler handler3 = (PropertyChangedEventHandler)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChangedEventHandler_0, handler3, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected void NotifyPropertyChanged<TExp>(Expression<Func<TExp>> expression)
        {
            Class213<TExp> class2 = new Class213<TExp>
            {
                notificationObject_0 = this,
                string_0 = smethod_0<TExp>(expression)
            };
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(class2.method_0), Array.Empty<object>());
            }
        }

        private static string smethod_0<T>(Expression<Func<T>> expression_0)
        {
            if (expression_0.NodeType != ExpressionType.Lambda)
            {
                throw new ArgumentException("Value must be a lamda expression", "expression");
            }
            if (!(expression_0.Body is MemberExpression))
            {
                throw new ArgumentException("The body of the expression must be a memberref", "expression");
            }
            return ((MemberExpression)expression_0.Body).Member.Name;
        }

        [CompilerGenerated]
        private sealed class Class213<T>
        {
            public string string_0;
            public NotificationObject notificationObject_0;

            internal void method_0()
            {
                this.notificationObject_0.propertyChangedEventHandler_0?.Invoke(this.notificationObject_0, new PropertyChangedEventArgs(this.string_0));
            }
        }
    }
}

