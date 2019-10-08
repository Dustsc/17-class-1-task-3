using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.Triton.Common.Plugins
{
    using log4net;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Triton.Common;

    public static class PluginManager
    {
        private static ILog ilog_0 = Triton.Common.LogUtilities.LogManagers.GetLoggerInstanceForType();
        [CompilerGenerated]
        private static List<IPlugin> list_0;
        [CompilerGenerated]
        private static PluginEvent pluginEvent_0;
        [CompilerGenerated]
        private static PluginEvent pluginEvent_1;
        [CompilerGenerated]
        private static PluginEvent pluginEvent_2;
        [CompilerGenerated]
        private static PluginEvent pluginEvent_3;
        [CompilerGenerated]
        private static PluginEvent pluginEvent_4;
        [CompilerGenerated]
        private static PluginEvent pluginEvent_5;
        [CompilerGenerated]
        private static PluginEvent pluginEvent_6;
        [CompilerGenerated]
        private static PluginEvent pluginEvent_7;

        public static event PluginEvent PluginDisabled
        {
            [CompilerGenerated]
            add
            {
                PluginEvent objA = pluginEvent_7;
                while (true)
                {
                    PluginEvent a = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_7, event4, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PluginEvent objA = pluginEvent_7;
                while (true)
                {
                    PluginEvent source = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_7, event4, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public static event PluginEvent PluginEnabled
        {
            [CompilerGenerated]
            add
            {
                PluginEvent objA = pluginEvent_6;
                while (true)
                {
                    PluginEvent a = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_6, event4, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PluginEvent objA = pluginEvent_6;
                while (true)
                {
                    PluginEvent source = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_6, event4, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public static event PluginEvent PostStart
        {
            [CompilerGenerated]
            add
            {
                PluginEvent objA = pluginEvent_1;
                while (true)
                {
                    PluginEvent a = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_1, event4, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PluginEvent objA = pluginEvent_1;
                while (true)
                {
                    PluginEvent source = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_1, event4, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public static event PluginEvent PostStop
        {
            [CompilerGenerated]
            add
            {
                PluginEvent objA = pluginEvent_5;
                while (true)
                {
                    PluginEvent a = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_5, event4, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PluginEvent objA = pluginEvent_5;
                while (true)
                {
                    PluginEvent source = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_5, event4, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public static event PluginEvent PostTick
        {
            [CompilerGenerated]
            add
            {
                PluginEvent objA = pluginEvent_3;
                while (true)
                {
                    PluginEvent a = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_3, event4, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PluginEvent objA = pluginEvent_3;
                while (true)
                {
                    PluginEvent source = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_3, event4, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public static event PluginEvent PreStart
        {
            [CompilerGenerated]
            add
            {
                PluginEvent objA = pluginEvent_0;
                while (true)
                {
                    PluginEvent a = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_0, event4, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PluginEvent objA = pluginEvent_0;
                while (true)
                {
                    PluginEvent source = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_0, event4, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public static event PluginEvent PreStop
        {
            [CompilerGenerated]
            add
            {
                PluginEvent objA = pluginEvent_4;
                while (true)
                {
                    PluginEvent a = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_4, event4, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PluginEvent objA = pluginEvent_4;
                while (true)
                {
                    PluginEvent source = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_4, event4, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public static event PluginEvent PreTick
        {
            [CompilerGenerated]
            add
            {
                PluginEvent objA = pluginEvent_2;
                while (true)
                {
                    PluginEvent a = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_2, event4, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                PluginEvent objA = pluginEvent_2;
                while (true)
                {
                    PluginEvent source = objA;
                    PluginEvent event4 = (PluginEvent)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<PluginEvent>(ref pluginEvent_2, event4, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public static void Deinitialize()
        {
            if (Plugins != null)
            {
                foreach (IPlugin plugin in Plugins)
                {
                    try
                    {
                        plugin.Deinitialize();
                    }
                    catch (Exception exception)
                    {
                        ilog_0.ErrorFormat("[PluginManager] An exception occurred in {0}'s Deinitialize function. {1}", plugin.Name, exception);
                    }
                }
                Plugins.Clear();
            }
        }

        public static void Disable(IPlugin plugin)
        {
            try
            {
                if (plugin.IsEnabled)
                {
                    plugin.Disable();
                    smethod_3(plugin, pluginEvent_7);
                }
            }
            catch (Exception exception)
            {
                ilog_0.Error("Exception during plugin Disable.", exception);
            }
        }

        public static void Enable(IPlugin plugin)
        {
            try
            {
                if (!plugin.IsEnabled)
                {
                    plugin.Enable();
                    smethod_3(plugin, pluginEvent_6);
                }
            }
            catch (Exception exception)
            {
                ilog_0.Error("Exception during plugin Enable.", exception);
            }
        }

        public static bool Load()
        {
            bool flag;
            try
            {
                string pluginsPath = PluginsPath;
                if (Plugins != null)
                {
                    ilog_0.ErrorFormat("[Load] This function can only be called once.", Array.Empty<object>());
                    flag = false;
                }
                else
                {
                    if (!Directory.Exists(pluginsPath))
                    {
                        Directory.CreateDirectory(pluginsPath);
                    }
                    Plugins = new List<IPlugin>();
                    foreach (IPlugin plugin in new AssemblyLoader<IPlugin>(pluginsPath, false).Instances.AsReadOnly())
                    {
                        try
                        {
                            //Utility.smethod_0(plugin);
                            plugin.Initialize();
                            Plugins.Add(plugin);
                            
                        }
                        catch (Exception exception)
                        {
                            ilog_0.Debug("[Load] Exception thrown when initializing " + plugin.Name + ". Plugin will not be loaded.", exception);
                            //Utility.smethod_1(plugin);
                            plugin.Deinitialize();
                        }
                    }
                    flag = true;
                }
            }
            catch (Exception exception2)
            {
                ilog_0.ErrorFormat("[Load] An exception occurred: {0}.", exception2);
                return false;
            }
            return flag;
        }

        private static void smethod_0(IPlugin iplugin_0)
        {
            smethod_3(iplugin_0, pluginEvent_0);
            try
            {
                iplugin_0.Start();
            }
            catch (Exception exception)
            {
                ilog_0.Error("Exception during plugin Start.", exception);
            }
            smethod_3(iplugin_0, pluginEvent_1);
        }

        private static void smethod_1(IPlugin iplugin_0)
        {
            smethod_3(iplugin_0, pluginEvent_2);
            try
            {
                iplugin_0.Tick();
            }
            catch (Exception exception)
            {
                ilog_0.Error("Exception during plugin Tick.", exception);
            }
            smethod_3(iplugin_0, pluginEvent_3);
        }

        private static void smethod_2(IPlugin iplugin_0)
        {
            smethod_3(iplugin_0, pluginEvent_4);
            try
            {
                iplugin_0.Stop();
            }
            catch (Exception exception)
            {
                ilog_0.Error("Exception during plugin Stop.", exception);
            }
            smethod_3(iplugin_0, pluginEvent_5);
        }

        private static void smethod_3(IPlugin iplugin_0, PluginEvent pluginEvent_8)
        {
            if (pluginEvent_8 != null)
            {
                try
                {
                    pluginEvent_8(iplugin_0);
                }
                catch (Exception exception)
                {
                    ilog_0.Error("[Invoke] Error during execution:", exception);
                }
            }
        }

        public static void Start()
        {
            foreach (IPlugin plugin in Plugins)
            {
                if (plugin.IsEnabled)
                {
                    smethod_0(plugin);
                }
            }
        }

        public static void Stop()
        {
            foreach (IPlugin plugin in Plugins)
            {
                if (plugin.IsEnabled)
                {
                    smethod_2(plugin);
                }
            }
        }

        public static void Tick()
        {
            foreach (IPlugin plugin in Plugins)
            {
                if (plugin.IsEnabled)
                {
                    smethod_1(plugin);
                }
            }
        }

        public static List<IPlugin> Plugins
        {
            [CompilerGenerated]
            get
            {
                return list_0;
            }
            [CompilerGenerated]
            private set
            {
                list_0 = value;
            }
        }

        private static string String_0 =>
            Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static string PluginsPath =>
            Path.Combine(String_0, "Plugins");

        public static IEnumerable<IPlugin> EnabledPlugins =>
            Plugins.Where<IPlugin>((Class206.abc__45_0 ?? (Class206.abc__45_0 = new Func<IPlugin, bool>(Class206.abc.method_0))));

        public static IEnumerable<IPlugin> DisabledPlugins =>
            Plugins.Where<IPlugin>((Class206.abc__47_0 ?? (Class206.abc__47_0 = new Func<IPlugin, bool>(Class206.abc.method_1))));

        [Serializable, CompilerGenerated]
        private sealed class Class206
        {
            public static PluginManager.Class206 abc = new PluginManager.Class206();
            public static Func<IPlugin, bool> abc__45_0;
            public static Func<IPlugin, bool> abc__47_0;

            internal bool method_0(IPlugin iplugin_0) =>
                iplugin_0.IsEnabled;

            internal bool method_1(IPlugin iplugin_0) =>
                !iplugin_0.IsEnabled;
        }

        public delegate void PluginEvent(IPlugin plugin);
    }
}

