using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Triton.Common.Plugins
{
    using System;
    using System.Windows.Controls;
    using Triton.Common;

    public interface IRunnable
    {
        void Start();
        void Stop();
        void Tick();
    }

    public interface IAuthored
    {
        string Name { get; }

        string Author { get; }

        string Description { get; }

        string Version { get; }
    }

    public interface IBase
    {
        void Deinitialize();
        void Initialize();
    }

    public interface IConfigurable
    {
        UserControl Control { get; }
        JsonSettings Settings { get; }
    }

    public interface IEnableable
    {
        void Disable();
        void Enable();

        bool IsEnabled { get; }
    }

    public interface IPlugin : IRunnable, IAuthored, IBase, IConfigurable, IEnableable
    {
    }
}
