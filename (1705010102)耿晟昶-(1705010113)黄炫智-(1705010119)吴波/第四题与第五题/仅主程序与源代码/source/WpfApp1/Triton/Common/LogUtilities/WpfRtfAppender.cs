using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.Triton.Common.LogUtilities
{
    using log4net.Appender;
    using log4net.Core;
    using System;
    using System.Collections.Concurrent;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Media;
    using System.Windows.Threading;

    public class WpfRtfAppender : AppenderSkeleton
    {
        [CompilerGenerated]
        private SolidColorBrush normalColor;
        [CompilerGenerated]
        private SolidColorBrush warnColor;
        [CompilerGenerated]
        private SolidColorBrush errorColor;
        [CompilerGenerated]
        private SolidColorBrush messageColor;
        private readonly RichTextBox richTextBox_0;
        private readonly ScrollViewer scrollViewer_0;
        private int int_0;
        private readonly DispatcherTimer dispatcherTimer_0;
        private Paragraph paragraph_0;
        private readonly ConcurrentQueue<LoggingEvent> concurrentQueue_0 = new ConcurrentQueue<LoggingEvent>();

        public WpfRtfAppender(ScrollViewer scrollViewer, RichTextBox rtb)
        {
            this.scrollViewer_0 = scrollViewer;
            this.richTextBox_0 = rtb;
            this.normalColor = Brushes.White;
            this.warnColor = Brushes.Orange;
            this.errorColor = Brushes.Red;
            this.messageColor = Brushes.Yellow;
            this.normalColor.Freeze();
            this.warnColor.Freeze();
            this.errorColor.Freeze();
            this.messageColor.Freeze();
            this.dispatcherTimer_0 = new DispatcherTimer(TimeSpan.FromMilliseconds(100.0), (DispatcherPriority)9, new EventHandler(this.method_0), rtb.Dispatcher);
            this.dispatcherTimer_0.Start();
        }

        protected override void Append(LoggingEvent loggingEvent)
        {
            this.concurrentQueue_0.Enqueue(loggingEvent);
        }

        public void Clear()
        {
            this.paragraph_0.Inlines.Clear();
            this.int_0 = 0;
        }

        private void method_0(object sender, EventArgs e)
        {
            try
            {
                this.dispatcherTimer_0.Stop();
                StringBuilder builder = new StringBuilder();
                Action<StringBuilder, SolidColorBrush> action = new Action<StringBuilder, SolidColorBrush>(this.method_1);
                if (this.paragraph_0 == null)
                {
                    this.richTextBox_0.Document.Blocks.Clear();
                    this.paragraph_0 = new Paragraph
                    {
                        Margin = new Thickness(0.0)
                    };
                    this.richTextBox_0.Document.Blocks.Add(this.paragraph_0);
                }
                if (this.int_0 >= 0x7d0)
                {
                    this.paragraph_0.Inlines.Clear();
                    this.int_0 = 0;
                }
                while (true)
                {
                    if (!this.concurrentQueue_0.TryDequeue(out LoggingEvent event2))
                    {
                        if (builder.Length != 0)
                        {
                            action(builder, normalColor);
                            this.int_0++;
                        }
                        if (this.scrollViewer_0.ScrollableHeight.Equals(this.scrollViewer_0.ContentVerticalOffset))
                        {
                            this.scrollViewer_0.ScrollToEnd();
                        }
                        break;
                    }
                    event2.Fix = FixFlags.All;
                    string str = base.RenderLoggingEvent(event2);
                    string name = event2.Level.Name;
                    SolidColorBrush objA = (name == "DEBUG") ? this.warnColor : ((name == "ERROR") ? this.errorColor : ((name == "WARN") ? this.messageColor : this.normalColor));
                    action(builder, objA);
                    builder.Clear();
                    builder.AppendLine(str);
                    this.int_0++;
                }
            }
            finally
            {
                this.dispatcherTimer_0.Start();
            }
        }

        [CompilerGenerated]
        private void method_1(StringBuilder stringBuilder_0, SolidColorBrush solidColorBrush_4)
        {
            System.Windows.Documents.Run item = new System.Windows.Documents.Run(stringBuilder_0.ToString())
            {
                Foreground = solidColorBrush_4
            };
            this.paragraph_0.Inlines.Add(item);
        }

        public SolidColorBrush InfoBrush
        {
            [CompilerGenerated]
            get
            {
                return this.normalColor;
            }
            [CompilerGenerated]
            set
            {
                this.normalColor = value;
            }
        }

        public SolidColorBrush DebugBrush
        {
            [CompilerGenerated]
            get
            {
                return this.warnColor;
            }
            [CompilerGenerated]
            set
            {
                this.warnColor = value;
            }
        }

        public SolidColorBrush ErrorBrush
        {
            [CompilerGenerated]
            get
            {
                return this.errorColor;
            }
            [CompilerGenerated]
            set
            {
                this.errorColor = value;
            }
        }

        public SolidColorBrush WarnBrush
        {
            [CompilerGenerated]
            get
            {
                return this.messageColor;
            }
            [CompilerGenerated]
            set
            {
                this.messageColor = value;
            }
        }

        private delegate void Delegate5(LoggingEvent loggingEvent);
    }
}

