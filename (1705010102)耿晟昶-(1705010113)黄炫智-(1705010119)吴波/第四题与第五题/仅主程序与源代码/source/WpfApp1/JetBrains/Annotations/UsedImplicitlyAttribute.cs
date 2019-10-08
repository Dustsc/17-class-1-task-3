using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.JetBrains.Annotations
{
    using System;
    using System.Runtime.CompilerServices;

    [Flags]
    public enum ImplicitUseKindFlags
    {
        Default = 7,
        Access = 1,
        Assign = 2,
        InstantiatedWithFixedConstructorSignature = 4,
        InstantiatedNoFixedConstructorSignature = 8
    }

    [Flags]
    public enum ImplicitUseTargetFlags
    {
        Default = 1,
        Itself = 1,
        Members = 2,
        WithMembers = 3
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public sealed class UsedImplicitlyAttribute : Attribute
    {
        [CompilerGenerated]
        private ImplicitUseKindFlags implicitUseKindFlags_0;
        [CompilerGenerated]
        private ImplicitUseTargetFlags implicitUseTargetFlags_0;

        [UsedImplicitly]
        public UsedImplicitlyAttribute() : this(ImplicitUseKindFlags.Default, ImplicitUseTargetFlags.Default)
        {
        }

        [UsedImplicitly]
        public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags) : this(useKindFlags, ImplicitUseTargetFlags.Default)
        {
        }

        [UsedImplicitly]
        public UsedImplicitlyAttribute(ImplicitUseTargetFlags targetFlags) : this(ImplicitUseKindFlags.Default, targetFlags)
        {
        }

        [UsedImplicitly]
        public UsedImplicitlyAttribute(ImplicitUseKindFlags useKindFlags, ImplicitUseTargetFlags targetFlags)
        {
            this.UseKindFlags = useKindFlags;
            this.TargetFlags = targetFlags;
        }

        [UsedImplicitly]
        public ImplicitUseKindFlags UseKindFlags
        {
            [CompilerGenerated]
            get
            {
                return this.implicitUseKindFlags_0;
            }
            [CompilerGenerated]
            private set
            {
                this.implicitUseKindFlags_0 = value;
            }
        }

        [UsedImplicitly]
        public ImplicitUseTargetFlags TargetFlags
        {
            [CompilerGenerated]
            get
            {
                return this.implicitUseTargetFlags_0;
            }
            [CompilerGenerated]
            private set
            {
                this.implicitUseTargetFlags_0 = value;
            }
        }
    }
}

