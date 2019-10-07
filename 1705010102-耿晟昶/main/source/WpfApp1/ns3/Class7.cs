using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.ns3
{
    using ns2;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class Class7
    {
        private static string string_0 = "";
        private static string string_1 = "";

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr intptr_0);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr CreateFileW([MarshalAs(UnmanagedType.LPWStr)] string string_2, [MarshalAs(UnmanagedType.U4)] uint uint_0, [MarshalAs(UnmanagedType.U4)] uint uint_1, IntPtr intptr_0, [MarshalAs(UnmanagedType.U4)] uint uint_2, [MarshalAs(UnmanagedType.U4)] uint uint_3, IntPtr intptr_1);
        [return: MarshalAs(UnmanagedType.I1)]
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CreateSymbolicLink(string string_2, string string_3, Enum2 enum2_0);
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentProcess();
        [DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetFinalPathNameByHandle(IntPtr intptr_0, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder stringBuilder_0, uint uint_0, uint uint_1);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern uint GetLogicalDriveStrings(uint uint_0, [Out] char[] char_0);
        [DllImport("psapi.dll")]
        private static extern uint GetProcessImageFileName(IntPtr intptr_0, [Out] StringBuilder stringBuilder_0, [In, MarshalAs(UnmanagedType.U4)] int int_0);
        public Class6 method_0(string string_2)
        {
            Class6 class2;
            int num = 0;
            while (true)
            {
                bool flag;
                if (num >= 100)
                {
                    return Class6.smethod_2("Failed to rename after several tries");
                }
                if (num != 0)
                {
                    Thread.Sleep(100);
                }
                using (new Mutex(true, string_2 + "-Startup", out flag))
                {
                    if (flag)
                    {
                        string str;
                        if (!smethod_4(out str))
                        {
                            class2 = Class6.smethod_2("Could not get image file name");
                        }
                        else
                        {
                            string str2;
                            if (!File.Exists(str))
                            {
                                string location = Assembly.GetEntryAssembly().Location;
                                if (!File.Exists(location))
                                {
                                    string str5;
                                    string str4 = Path.Combine(Path.GetDirectoryName(str), string_2 + ".exe");
                                    if (!this.method_1(str4, out str5))
                                    {
                                        class2 = Class6.smethod_2("Someone else won the rename race but the sym link could not be resolved");
                                    }
                                    else
                                    {
                                        smethod_5(string_2, str);
                                        class2 = Class6.smethod_0(str5);
                                    }
                                    break;
                                }
                                str = location;
                            }
                            if (!this.method_1(str, out str2))
                            {
                                class2 = Class6.smethod_2("Could not get final path for image file name");
                            }
                            else if (!string.Equals(str, str2, StringComparison.OrdinalIgnoreCase))
                            {
                                class2 = Class6.smethod_1(str);
                            }
                            else
                            {
                                Class6 class1 = smethod_0(str, string_2);
                                if (class1.Enum1_0 == Enum1.Success)
                                {
                                    smethod_5(string_2, str);
                                }
                                class2 = class1;
                            }
                        }
                        break;
                    }
                }
                num++;
            }
            return class2;
        }

        private bool method_1(string string_2, out string string_3)
        {
            string_3 = null;
            IntPtr ptr = CreateFileW(string_2, 0x80000000, 1, IntPtr.Zero, 3, 0x80, IntPtr.Zero);
            if (ptr == new IntPtr(-1))
            {
                return false;
            }
            try
            {
                StringBuilder builder = new StringBuilder(260);
                while (true)
                {
                    uint num = GetFinalPathNameByHandle(ptr, builder, (uint)builder.Capacity, 0);
                    if (num != 0)
                    {
                        if (num >= builder.Capacity)
                        {
                            builder.Capacity = (int)num;
                            continue;
                        }
                        string_3 = builder.ToString();
                        if (string_3.StartsWith(@"\\?\"))
                        {
                            string_3 = string_3.Substring(4);
                        }
                    }
                    else
                    {
                        return false;
                    }
                    break;
                }
            }
            finally
            {
                CloseHandle(ptr);
            }
            return true;
        }

        [DllImport("kernel32.dll")]
        private static extern uint QueryDosDevice(string string_2, StringBuilder stringBuilder_0, uint uint_0);
        private static Class6 smethod_0(string string_2, string string_3)
        {
            string path = Path.Combine(Path.GetDirectoryName(string_2), string_3 + ".exe");
            //File.Delete(path);
            if (CreateSymbolicLink(path, Path.GetFileName(smethod_1(string_2)), Enum2.File))
            {
                return (!string.Equals(string_2, path, StringComparison.OrdinalIgnoreCase) ? Class6.smethod_0(path) : Class6.smethod_1(path));
            }
            if (Marshal.GetLastWin32Error() == 1)
            {
                throw new Exception("Could not setup new sym link - the device does not support symbolic links.\r\n" + $"Please make sure the drive you are attempting to use {string_3} on is " + $"formatted with the NTFS file system, or copy {string_3} to the system drive.");
            }
            Win32Exception exception = new Win32Exception();
            throw new Exception($"Could not setup new sym link - {exception.Message} ({exception.NativeErrorCode:x8}");
        }

        private static string smethod_1(string string_2)
        {
            string destFileName = smethod_2(Path.GetDirectoryName(string_2));
            File.Move(string_2, destFileName);
            string path = Path.ChangeExtension(string_2, ".exe.config");
            if (File.Exists(path))
            {
                try
                {
                    string str3 = Path.Combine(Path.GetDirectoryName(destFileName), Path.GetFileNameWithoutExtension(destFileName) + ".exe.config");
                    if (File.Exists(str3))
                    {
                        File.Delete(str3);
                    }
                    File.Move(path, str3);
                }
                catch
                {
                }
            }
            return destFileName;
        }

        private static string smethod_2(string string_2)
        {
            Random random = new Random(smethod_3(Environment.UserName + "unique"));
            StringBuilder builder = new StringBuilder(10);
            while (true)
            {
                builder.Clear();
                int num = 0;
                while (true)
                {
                    if (num >= builder.Capacity)
                    {
                        if (!Process.GetProcessesByName(builder.ToString()).Any<Process>())
                        {
                            string path = Path.Combine(string_2, builder + ".exe");
                            if (!File.Exists(path))
                            {
                                return path;
                            }
                        }
                        break;
                    }
                    builder.Append("abcdefghijklmnopqrstuvxyz"[random.Next("abcdefghijklmnopqrstuvxyz".Length)]);
                    num++;
                }
            }
        }

        private static int smethod_3(string string_2)
        {
            uint num = 0x811c9dc5;
            foreach (char ch in string_2)
            {
                num = (((num * 0x1000193) ^ ((byte)ch)) * 0x1000193) ^ ((byte)(ch >> 8));
            }
            return (int)num;
        }

        internal static bool smethod_4(out string string_2)
        {
            string_2 = null;
            StringBuilder builder = new StringBuilder(260);
            if (GetProcessImageFileName(GetCurrentProcess(), builder, 260) != 0)
            {
                char[] chArray = new char[0x1000];
                if (GetLogicalDriveStrings(0xfff, chArray) == 0)
                {
                    return false;
                }
                int index = 0;
                while (index < chArray.Length)
                {
                    string str = chArray[index].ToString() + ":";
                    StringBuilder builder2 = new StringBuilder(260);
                    if ((QueryDosDevice(str, builder2, 260) != 0) && builder.ToString().StartsWith(builder2.ToString()))
                    {
                        string_2 = str + builder.ToString(builder2.Length, builder.Length - builder2.Length);
                        return true;
                    }
                    while (true)
                    {
                        if (chArray[index] == '\0')
                        {
                            index++;
                            break;
                        }
                        index++;
                    }
                }
            }
            return false;
        }

        private static void smethod_5(string string_2, string string_3)
        {
            string_0 = string_2;
            string_1 = string_3;
        }

        internal static void smethod_6(byte[] byte_0)
        {
            Class8 class1 = new Class8();
            class1.byte_0 = byte_0;
            Task.Run(new Func<Task>(class1.method_0));
        }

        [CompilerGenerated]
        private sealed class Class8
        {
            public byte[] byte_0;

            [AsyncStateMachine(typeof(Struct2))]
            internal Task method_0()
            {
                Struct2 struct2;
                struct2.class8_0 = this;
                struct2.asyncTaskMethodBuilder_0 = AsyncTaskMethodBuilder.Create();
                struct2.int_0 = -1;
                struct2.asyncTaskMethodBuilder_0.Start<Struct2>(ref struct2);
                return struct2.asyncTaskMethodBuilder_0.Task;
            }

            private struct Struct2 : IAsyncStateMachine
            {
                public int int_0;
                public AsyncTaskMethodBuilder asyncTaskMethodBuilder_0;
                public Class7.Class8 class8_0;
                private TaskAwaiter taskAwaiter_0;

                public void MoveNext()
                {
                    int num = this.int_0;
                    try
                    {
                        TaskAwaiter awaiter;
                        if (num != 0)
                        {
                            goto TR_001B;
                        }
                        else
                        {
                            awaiter = this.taskAwaiter_0;
                            this.taskAwaiter_0 = new TaskAwaiter();
                            num = -1;
                            this.int_0 = -1;
                        }
                        goto TR_001D;
                        TR_0003:
                        awaiter = Task.Delay(0x3e8).GetAwaiter();
                        if (!awaiter.IsCompleted)
                        {
                            num = 0;
                            this.int_0 = 0;
                            this.taskAwaiter_0 = awaiter;
                            this.asyncTaskMethodBuilder_0.AwaitUnsafeOnCompleted<TaskAwaiter, Class7.Class8.Struct2>(ref awaiter, ref this);
                            return;
                        }
                        goto TR_001D;
                        TR_0005:
                        Process.GetCurrentProcess().Kill();
                        goto TR_0003;
                        TR_001B:
                        if (File.Exists(Class7.string_1))
                        {
                            try
                            {
                                if (this.class8_0.byte_0.SequenceEqual<byte>(File.ReadAllBytes(Class7.string_1)))
                                {
                                    goto TR_0003;
                                }
                                else
                                {
                                    try
                                    {
                                        File.AppendAllText("fatal-rename.txt", DateTime.Now + Environment.NewLine);
                                    }
                                    catch
                                    {
                                    }
                                    try
                                    {
                                        EventLog log = new EventLog("Application");
                                        try
                                        {
                                            log.Source = Class7.string_0;
                                            log.WriteEntry($"{Class7.string_0} detected a dangerous file rename and terminated itself for safety.", EventLogEntryType.Error);
                                        }
                                        finally
                                        {
                                            if ((num < 0) && (log != null))
                                            {
                                                log.Dispose();
                                            }
                                        }
                                    }
                                    catch
                                    {
                                    }
                                }
                                Process.GetCurrentProcess().Kill();
                            }
                            catch (Exception)
                            {
                            }
                            goto TR_0003;
                        }
                        else
                        {
                            try
                            {
                                File.AppendAllText("fatal-removal.txt", DateTime.Now + Environment.NewLine);
                            }
                            catch
                            {
                            }
                            try
                            {
                                EventLog log2 = new EventLog("Application");
                                try
                                {
                                    log2.Source = Class7.string_0;
                                    log2.WriteEntry($"{Class7.string_0} detected a dangerous file removal and terminated itself for safety.", EventLogEntryType.Error);
                                }
                                finally
                                {
                                    if ((num < 0) && (log2 != null))
                                    {
                                        log2.Dispose();
                                    }
                                }
                            }
                            catch
                            {
                            }
                        }
                        goto TR_0005;
                        TR_001D:
                        while (true)
                        {
                            awaiter.GetResult();
                            awaiter = new TaskAwaiter();
                            break;
                        }
                        goto TR_001B;
                    }
                    catch (Exception exception)
                    {
                        this.int_0 = -2;
                        this.asyncTaskMethodBuilder_0.SetException(exception);
                    }
                }

                [DebuggerHidden]
                public void SetStateMachine(IAsyncStateMachine stateMachine)
                {
                    this.asyncTaskMethodBuilder_0.SetStateMachine(stateMachine);
                }
            }
        }

        private enum Enum2
        {
            File,
            Directory
        }
    }
}

