using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Triton.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public class TypeLoader<T> : List<T>
    {
        private readonly Assembly assembly_0;
        private readonly Func<object[]> func_0;

        public TypeLoader(Assembly asm = null, Func<object[]> constructorArguments = null)
        {
            this.assembly_0 = asm;
            this.func_0 = constructorArguments ?? Class236<T>.abc__2_0 ?? (Class236<T>.abc__2_0 = new Func<object[]>(Class236<T>.abc.method_0));
            this.Reload();
        }

        private void method_0(params Assembly[] assembly_1)
        {
            using (IEnumerator<Type> enumerator = assembly_1.SelectMany<Assembly, Type>((Class236<T>.abc__3_0 ?? (Class236<T>.abc__3_0 = new Func<Assembly, IEnumerable<Type>>(Class236<T>.abc.method_1)))).GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Class237<T> class2 = new Class237<T>
                    {
                        type_0 = enumerator.Current
                    };
                    if (!this.Any<T>(new Func<T, bool>(class2.method_0)))
                    {
                        Triton.Common.LogUtilities.LogManagers.GetLoggerInstanceForType().Debug(class2.type_0.FullName);
                        base.Add((T)Activator.CreateInstance(class2.type_0, BindingFlags.CreateInstance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, this.func_0(), CultureInfo.InvariantCulture));
                    }
                }
            }
        }

        public void Reload()
        {
            base.Clear();
            if (this.assembly_0 == null)
            {
                this.method_0(AppDomain.CurrentDomain.GetAssemblies());
            }
            else
            {
                Assembly[] assemblyArray1 = new Assembly[] { this.assembly_0 };
                this.method_0(assemblyArray1);
            }
        }

        [Serializable, CompilerGenerated]
        private sealed class Class236<T>
        {
            public static TypeLoader<T>.Class236<T> abc;
            public static Func<object[]> abc__2_0;
            public static Func<Type, bool> abc__3_2;
            public static Func<Type, bool> abc__3_1;
            public static Func<Assembly, IEnumerable<Type>> abc__3_0;

            static Class236()
            {
                TypeLoader<T>.Class236<T>.abc = new TypeLoader<T>.Class236<T>();
            }

            internal object[] method_0() =>
                null;

            internal IEnumerable<Type> method_1(Assembly assembly_0) =>
                assembly_0.GetTypes().Where<Type>((TypeLoader<T>.Class236<T>.abc__3_1 ?? (TypeLoader<T>.Class236<T>.abc__3_1 = new Func<Type, bool>(TypeLoader<T>.Class236<T>.abc.method_2))));

            internal bool method_2(Type type_0) =>
                (!type_0.IsAbstract && (type_0.IsSubclassOf(typeof(T)) || type_0.GetInterfaces().Any<Type>((TypeLoader<T>.Class236<T>.abc__3_2 ?? (TypeLoader<T>.Class236<T>.abc__3_2 = new Func<Type, bool>(TypeLoader<T>.Class236<T>.abc.method_3))))));

            internal bool method_3(Type type_0) =>
                (type_0 == typeof(T));
        }

        [CompilerGenerated]
        private sealed class Class237<T>
        {
            public Type type_0;

            internal bool method_0(T gparam_0) =>
                (gparam_0.GetType().FullName == this.type_0.FullName);
        }
    }
}

