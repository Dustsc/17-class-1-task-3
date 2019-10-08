using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Triton.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public static class CommandLine
    {
        [CompilerGenerated]
        private static Triton.Common.Arguments arguments_0;

        static CommandLine()
        {
            Arguments = new Triton.Common.Arguments(Environment.GetCommandLineArgs());
        }

        public static Triton.Common.Arguments Arguments
        {
            [CompilerGenerated]
            get
            {
                return arguments_0;
            }
            [CompilerGenerated]
            private set
            {
                arguments_0 = value;
            }
        }
    }
}

