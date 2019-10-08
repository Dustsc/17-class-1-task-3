using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.Triton.Common
{
    using log4net;
    using System;
    using System.Collections.Generic;
    using Triton.Common;

    [Obsolete("This function is obsolete", true)]
    public static class Utility
    {
        private static readonly ILog ilog_0 = Triton.Common.LogUtilities.LogManagers.GetLoggerInstanceForType();
        public static System.Random Random = new System.Random();
    }
}

