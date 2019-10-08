using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.Triton.Common
{
    using log4net;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Triton.Common.LogUtilities;

    public class AssemblyLoader<T>
    {
        private readonly ILog ilog_0 = Triton.Common.LogUtilities.LogManagers.GetLoggerInstanceForType();
        private readonly bool bool_0;
        private readonly string string_0;
        private readonly FileSystemWatcher fileSystemWatcher_0;
        [CompilerGenerated]
        private List<T> list_0;
        [CompilerGenerated]
        private EventHandler eventHandler_0;

        public event EventHandler Reloaded
        {
            [CompilerGenerated]
            add
            {
                EventHandler objA = this.eventHandler_0;
                while (true)
                {
                    EventHandler a = objA;
                    EventHandler handler3 = (EventHandler)Delegate.Combine(a, value);
                    objA = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, handler3, a);
                    if (ReferenceEquals(objA, a))
                    {
                        return;
                    }
                }
            }
            [CompilerGenerated]
            remove
            {
                EventHandler objA = this.eventHandler_0;
                while (true)
                {
                    EventHandler source = objA;
                    EventHandler handler3 = (EventHandler)Delegate.Remove(source, value);
                    objA = Interlocked.CompareExchange<EventHandler>(ref this.eventHandler_0, handler3, source);
                    if (ReferenceEquals(objA, source))
                    {
                        return;
                    }
                }
            }
        }

        public AssemblyLoader(string directory, bool detectFileChanges)
        {
            this.fileSystemWatcher_0 = new FileSystemWatcher();
            this.Instances = new List<T>();
            this.string_0 = directory;
            this.bool_0 = detectFileChanges;
            if (this.bool_0)
            {
                this.fileSystemWatcher_0.Path = directory;
                this.fileSystemWatcher_0.Filter = "*.cs";
                this.fileSystemWatcher_0.IncludeSubdirectories = true;
                this.fileSystemWatcher_0.EnableRaisingEvents = true;
                this.fileSystemWatcher_0.Changed += new FileSystemEventHandler(this.Events_Reload);
                this.fileSystemWatcher_0.Created += new FileSystemEventHandler(this.Events_Reload);
                this.fileSystemWatcher_0.Deleted += new FileSystemEventHandler(this.Events_Reload);
            }
            this.Reload("Initializing");
        }

        [CompilerGenerated]
        private void Events_Reload(object sender, FileSystemEventArgs e)
        {
            this.Reload(e.ChangeType.ToString());
        }

        public void Reload(string reason)
        {
            this.ilog_0.Debug($"Reloading AssemblyLoader<{typeof(T)}> - {reason}");
            this.Instances = new List<T>();
            if (!Directory.Exists(this.string_0))
            {
                this.ilog_0.Error(string.Format("Could not Reload assemblies because the path \"{0}\" does not exist.", this.string_0));
            }
            else
            {
                string[] directories = Directory.GetDirectories(this.string_0);
                int index = 0;
                while (true)
                {
                    while (true)
                    {
                        if (index >= directories.Length)
                        {
                            using (List<T>.Enumerator enumerator2 = new TypeLoader<T>(null, null).GetEnumerator())
                            {
                                while (enumerator2.MoveNext())
                                {
                                    Class229 class2 = new Class229
                                    {
                                        gparam_0 = enumerator2.Current
                                    };
                                    if (!this.Instances.Any<T>(new Func<T, bool>(class2.Compare_Name)))
                                    {
                                        this.Instances.Add(class2.gparam_0);
                                    }
                                }
                            }
                            this.eventHandler_0?.Invoke(this, null);
                            return;
                        }
                        string path = directories[index];
                        try
                        {
                            Triton.Common.Codecompiler.CodeCompiler compiler = new Triton.Common.Codecompiler.CodeCompiler(path);
                            CompilerResults results = compiler.Compile();
                            if (results != null)
                            {
                                if (!results.Errors.HasErrors)
                                {
                                    this.Instances.AddRange(new TypeLoader<T>(compiler.CompiledAssembly, null));
                                }
                                else
                                {
                                    foreach (object obj2 in results.Errors)
                                    {
                                        this.ilog_0.Error("Compiler Error: " + obj2.ToString());
                                    }
                                }
                            }
                        }
                        catch (Exception exception)
                        {
                            if (!(exception is ReflectionTypeLoadException))
                            {
                                this.ilog_0.Error("[Reload] An exception occurred.", exception);
                            }
                            else
                            {
                                foreach (Exception exception2 in (exception as ReflectionTypeLoadException).LoaderExceptions)
                                {
                                    this.ilog_0.Error("[Reload] An exception occurred.", exception2);
                                }
                            }
                        }
                        break;
                    }
                    index++;
                }
            }
        }

        public List<T> Instances
        {
            [CompilerGenerated]
            get
            {
                return this.list_0;
            }
            [CompilerGenerated]
            private set
            {
                this.list_0 = value;
            }
        }

        [CompilerGenerated]
        private sealed class Class229
        {
            public T gparam_0;

            internal bool Compare_Name(T gparam_1) =>
                (gparam_1.GetType().FullName == this.gparam_0.GetType().FullName);
        }
    }
}

