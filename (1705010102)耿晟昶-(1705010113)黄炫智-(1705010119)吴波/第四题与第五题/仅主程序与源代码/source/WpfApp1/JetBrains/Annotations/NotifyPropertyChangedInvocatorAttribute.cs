using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.JetBrains.Annotations
{
    using System;
    using System.Runtime.CompilerServices;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class NotifyPropertyChangedInvocatorAttribute : Attribute
    {
        [CompilerGenerated]
        private string string_0;

        public NotifyPropertyChangedInvocatorAttribute()
        {
        }

        public NotifyPropertyChangedInvocatorAttribute(string parameterName)
        {
            this.ParameterName = parameterName;
        }

        [UsedImplicitly]
        public string ParameterName
        {
            [CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [CompilerGenerated]
            private set
            {
                this.string_0 = value;
            }
        }
    }
}

