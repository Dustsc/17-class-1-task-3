using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Triton.Common.settings
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using Triton.Common;
    using Triton.Common.LogUtilities;
    using log4net;
    /// <summary>
    /// 全局设置
    /// </summary>
    public class Globalsetting
    {
        private static readonly ILog ilog_0 = Triton.Common.LogUtilities.LogManagers.GetLoggerInstanceForType();
        private static Globalsetting globalsetting_0 = null;
        private List<string> list_0;

        public Globalsetting(){
        }

        public static Globalsetting Instance
        {
            get { return globalsetting_0 ?? (globalsetting_0 = new Globalsetting()); }
        }
        
        public List<string> EnabledPlugins
        {
            get
            {
                return this.list_0 ?? (list_0=new List<string>());
            }
            set
            {
                if (value.Equals(this.list_0))
                {
                    return;
                }
                this.list_0 = value;
            }
        }
    }
}
