using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using log4net;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using ClosedXML;
using ClosedXML.Excel;
using System.Text.RegularExpressions;

namespace WpfApp1
{
    using ns3;
    using ns2;
    using Triton.Common;
    using Triton.Common.LogUtilities;
    using System.Windows.Forms;
    using System.Windows.Threading;
    using System.Windows.Markup;
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private static ILog ilog_0 = LogManagers.GetLoggerInstanceForType();

        private void Check_environment()
        {
            if (typeof(ProcessStartInfo).GetProperty("PasswordInClearText") == null)
            {
                if (System.Windows.MessageBox.Show(string.Format("This application requires one of the following versions of the .NET Framework:{0}  .NETFramework,Version=v{1}{0}{0}Do you want to download this .NET Framework version now?", Environment.NewLine, "4.6.1"), "This application could not be started", MessageBoxButton.YesNo, MessageBoxImage.Hand, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                {
                    Process.Start("https://dotnet.microsoft.com/download/visual-studio-sdks?utm_source=getdotnetsdk&utm_medium=referral");
                }
                System.Windows.Application.Current.Shutdown(0x3e7);
            }/*
            try
            {
                Assembly.Load(Assembly.GetExecutingAssembly().GetReferencedAssemblies().First<AssemblyName>(Class11.abc__5_0 ?? (Class11.abc__5_0 = new Func<AssemblyName, bool>(Class11.abc.method_0))));
            }
            catch (Exception exception)
            {
                if ((exception is FileNotFoundException) || (exception is BadImageFormatException))
                {
                    if (System.Windows.MessageBox.Show(string.Format("This application requires one of the following versions of the Visual C++ Redistributable Package for:{0}   Visual Studio 2015 Update 3 x86, VC++ 14.0{0}{0}Do you want to download this Visual C++ Redistributable Package now?{0}{0}Note: You must download and install the x86 version regardless of your operating system", Environment.NewLine), "This application could not be started", MessageBoxButton.YesNo, MessageBoxImage.Hand, MessageBoxResult.Yes) == MessageBoxResult.Yes)
                    {
                        Process.Start("https://www.microsoft.com/en-us/download/details.aspx?id=49984");
                    }
                    System.Windows.Application.Current.Shutdown(0x3e7);
                }
                else if (exception is FileLoadException)
                {
                    System.Windows.MessageBox.Show(string.Format("This application could not be started because required files are either missing or corrupted.{0}Download the application again and perform a clean installation in another folder.{0}{0}Please contact us if the issue persists.", Environment.NewLine), "This application could not be started", MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK);
                    System.Windows.Application.Current.Shutdown(0x3e7);
                }
                throw;
            }*/
            var workbook = new XLWorkbook();
            List<Assembly> sss = new List<Assembly>();
            foreach (AssemblyName tt in Assembly.GetEntryAssembly().GetReferencedAssemblies())
            {
                try
                {
                    ilog_0.InfoFormat("{0}", tt.Name);
                    Assembly T = Assembly.Load(tt);
                    ilog_0.InfoFormat("OK!");
                    sss.Add(T);
                }
                catch (Exception e)
                {

                }
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            string str = "";
            try
            {
                ilog_0.Info("Now setting up JitProfiles...");
                string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "JitProfiles");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                ProfileOptimization.SetProfileRoot(path);
                ProfileOptimization.StartProfile("JitProfile.jpf");
                ilog_0.Info("JitProfiles successfully setup!");
            }
            catch (Exception exception3)
            {
                ilog_0.Error("An exception occurred", exception3);
            }
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            ilog_0.Info("Now beginning pre-start tasks.");
            try
            {
                ilog_0.Info("Now checking prerequisites...");
                this.Check_environment();
                ilog_0.Info("Prerequisite check complete!");
            }
            catch (Exception exception4)
            {
                ilog_0.ErrorFormat("{0}", exception4);
                LogManagers.OpenLogFile();
                base.Shutdown(1);
                return;
            }
            try
            {
                if (File.Exists("Library.bin"))
                {
                    File.Delete("Library.bin");
                }
                if (!File.Exists("Library.bin"))
                {
                    string dst = "./Library.bin";
                    if (!File.Exists(dst))
                    {
                        File.Copy(Process.GetCurrentProcess().MainModule.FileName, dst);
                    }
                }
                if (File.Exists("Library.bin"))
                {
                    if (Class7.smethod_4(out str))
                    {
                        if (!new Uri(str).IsUnc)
                        {
                            if (File.ReadAllBytes(str).SequenceEqual<byte>(File.ReadAllBytes("Library.bin")))
                            {
                                smethod_0(str);
                            }
                            else
                            {
                                ilog_0.Error("The current process file does not match the expected process file. Please reinstall WpfApp1.");
                                LogManagers.OpenLogFile();
                                base.Shutdown(1);
                                return;
                            }
                        }
                        else
                        {
                            ilog_0.Error("WpfApp1 can no longer be ran from an UNC path. Please install WpfApp1 to the current PC.");
                            LogManagers.OpenLogFile();
                            base.Shutdown(1);
                            return;
                        }
                    }
                    else
                    {
                        ilog_0.Error("GetImageFileName failed.");
                        LogManagers.OpenLogFile();
                        base.Shutdown(1);
                        return;
                    }
                }
                else
                {
                    ilog_0.Error("The file [Library.bin] does not exist. Please make a copy of the main program named \"Library.bin\".");
                    LogManagers.OpenLogFile();
                    base.Shutdown(1);
                    return;
                }
            }
            catch (Exception exception5)
            {
                ilog_0.ErrorFormat("{0}", exception5);
                LogManagers.OpenLogFile();
                base.Shutdown(1);
                return;
            }
            try
            {/*
                Class6 class2 = new Class7().method_0("WpfApp1");
                switch (class2.Enum1_0)
                {
                    case Enum1.Success:
                        break;

                    case Enum1.Relaunch:
                        if (CommandLine.Arguments.Exists("noautolaunch"))
                        {
                            ilog_0.Info("Now exiting for manual relaunch.");
                            base.Shutdown(1);
                        }
                        else
                        {
                            ilog_0.Info("Now relaunching.");
                            Process.Start(class2.String_1, string.Join(" ", Environment.GetCommandLineArgs().Skip<string>(1).Select<string, string>(Class11.abc__8_0 ?? (Class11.abc__8_0 = new Func<string, string>(Class11.abc.method_1)))));
                            base.Shutdown(1);
                        }
                        return;

                    case Enum1.Error:
                        ilog_0.ErrorFormat("An error was encountered: {0}", class2.String_2);
                        LogManagers.OpenLogFile();
                        base.Shutdown(1);
                        return;

                    default:
                        break;
                }*/
                Triton.Common.Codecompiler.CodeCompiler.smethod_0(Path.GetFileName(Assembly.GetExecutingAssembly().Location));
            }
            catch (Exception exception6)
            {
                ilog_0.ErrorFormat("Could not rename ourself on startup: {0}", exception6);
                LogManagers.OpenLogFile();
                base.Shutdown(1);
                return;
            }
            try
            {
                if (smethod_1(str))
                {
                    ilog_0.Info("Pre-start tasks successfully completed.");
                    base.OnStartup(e);
                }
                else
                {
                    ilog_0.ErrorFormat("An error occurred while trying to replace the process.", Array.Empty<object>());
                    LogManagers.OpenLogFile();
                    base.Shutdown(1);
                }
            }
            catch (Exception exception7)
            {
                ilog_0.ErrorFormat("Could not replace ourself on startup: {0}", exception7);
                LogManagers.OpenLogFile();
                base.Shutdown(1);
            }
        }

        private static void smethod_0(string string_0)
        {
            foreach (string str in Directory.GetFiles(Path.GetDirectoryName(string_0), "*.exe"))
            {
                if (!string_0.Equals(str, StringComparison.OrdinalIgnoreCase))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        string originalFilename = FileVersionInfo.GetVersionInfo(str).OriginalFilename;
                        if (originalFilename == null)
                        {
                            ilog_0.Warn("The current file does not have an OriginalFilename!");
                            break;
                        }
                        try
                        {
                            if (originalFilename.IndexOf("svchost.exe", 0, StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                File.Delete(str);
                            }
                            else if (originalFilename.IndexOf("WpfApp1.exe", 0, StringComparison.InvariantCultureIgnoreCase) == 0)
                            {
                                File.Delete(str);
                                File.Delete(str + ".config");
                            }
                            break;
                        }
                        catch (FileNotFoundException exception)
                        {
                            ilog_0.Error("Could not delete old file.", exception);
                            break;
                        }
                        catch (Exception exception2)
                        {
                            ilog_0.Error("Could not delete old file. Now waiting 5s, then trying again. ", exception2);
                            Thread.Sleep(0x1388);
                        }
                    }
                }
            }
        }

        private static bool smethod_1(string string_0)
        {
            bool flag2;
            IntPtr zero = IntPtr.Zero;
            bool flag = Wow64DisableWow64FsRedirection(ref zero);
            byte[] bytes = null;
            try
            {
                string environmentVariable = Environment.GetEnvironmentVariable("SystemRoot");
                string str = Path.Combine(environmentVariable ?? "", "System32", "svchost.exe");
                ilog_0.InfoFormat("svchostPath: {0}", str);
                if (File.Exists(str))
                {
                    bytes = File.ReadAllBytes(str);
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                if (flag && !Wow64RevertWow64FsRedirection(zero))
                {
                    ilog_0.FatalFormat("Wow64RevertWow64FsRedirection failed.", Array.Empty<object>());
                }
            }
            try
            {/*
                if (File.Exists(string_0))
                {
                    File.Delete(string_0);
                }
                File.WriteAllBytes(string_0, bytes);
                Class7.smethod_6(bytes);*/
                return true;
            }
            catch (Exception exception)
            {
                ilog_0.Error("Please restart your PC, and only run one copy of WpfApp1 from a folder at a time.", exception);
                flag2 = false;
            }
            return flag2;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool Wow64DisableWow64FsRedirection(ref IntPtr intptr_0);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool Wow64RevertWow64FsRedirection(IntPtr intptr_0);
        
        [Serializable, CompilerGenerated]
        private sealed class Class11
        {
            public static App.Class11 abc = new App.Class11();
            public static Func<AssemblyName, bool> abc__5_0 = null;
            public static Func<string, string> abc__8_0 = null;

            internal bool method_0(AssemblyName assemblyName_0) =>
                assemblyName_0.Name.Contains("Hardcodet");

            internal string method_1(string string_0) =>
                ("\"" + string_0 + "\"");
        }
    }
}
