using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Core;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Controls;

namespace WpfApp1.Triton.Common.LogUtilities
{
    public static class LogManagers
    {
        private static CustomLogger customLogger_0 = new CustomLogger("Logs", "WpfApp1", Level.All, Level.Emergency);
        private const string string_0 = "WpfApp1";
        private static Stopwatch stopwatch_0 = new Stopwatch();

        public static void AddWpfListener(ScrollViewer scrollViewer, RichTextBox rtbLog)
        {
            customLogger_0.AddWpfListener(scrollViewer, rtbLog);
        }

        public static void ChangeLogFilterLevel(Level minLevel = null, Level maxLevel = null)
        {
            customLogger_0.ChangeLogFilterLevel(minLevel, maxLevel);
        }

        public static void Clear()
        {
            customLogger_0.Clear();
        }

        public static ILog GetLoggerInstanceForType() =>
            customLogger_0.GetLoggerInstanceForType();

        public static void OpenLogFile()
        {
            if (!stopwatch_0.IsRunning)
            {
                stopwatch_0.Start();
            }
            else
            {
                if (stopwatch_0.ElapsedMilliseconds < 0x7530L)
                {
                    return;
                }
                stopwatch_0.Restart();
            }
            try
            {
                Process.Start(FileName);
            }
            catch
            {
            }
        }

        public static string FileName =>
            customLogger_0.FileName;
    }
}

