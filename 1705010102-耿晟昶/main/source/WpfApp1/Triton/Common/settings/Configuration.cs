using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Triton.Common.settings
{
    /// <summary>
    /// 全局设置
    /// </summary>
    public class Configuration
    {
        private static Configuration configuration_0 = null;
        public string Name = "Default";

        public Configuration(){
        }

        public static Configuration Instance
        {
            get { return configuration_0 ?? (configuration_0 = new Configuration()); }
        }
    }
}
