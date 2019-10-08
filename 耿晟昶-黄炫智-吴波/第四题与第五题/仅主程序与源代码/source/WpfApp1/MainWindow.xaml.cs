using log4net;
using Microsoft.CSharp;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Threading;

namespace WpfApp1
{
    using Triton.Common.Plugins;
    using Triton.Common.settings;

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private static ILog ilog_0 = Triton.Common.LogUtilities.LogManagers.GetLoggerInstanceForType();
        private IPlugin IPlugin_0=null;

        public MainWindow()
        {
            InitializeComponent();
            Triton.Common.LogUtilities.LogManagers.AddWpfListener(scrollViewer0, LogTextBox0);
            PluginManager.Load();
            foreach (IPlugin plugin in PluginManager.Plugins)
            {
                if (Globalsetting.Instance.EnabledPlugins.Contains(plugin.Name))
                {
                    PluginManager.Enable(plugin);
                    Thread.Sleep(20);
                    continue;
                }
                PluginManager.Disable(plugin);
                Thread.Sleep(20);
            }
            this.list_plugins.Dispatcher.Invoke<IEnumerable>(new Func<IEnumerable>(this.Show_IPlugins), DispatcherPriority.Normal);
            base.Dispatcher.Invoke(new Action(this.Thread_Load_Plugins));
            PluginManager.PluginEnabled += new PluginManager.PluginEvent(this.Thread_TabItem);
            PluginManager.PluginDisabled += new PluginManager.PluginEvent(this.Thread_TabItem);
        }

        private void List_plugins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (list_plugins.SelectedItems.Count > 1) return;
            if (list_plugins.SelectedItems.Count <= 0) return;
            IPlugin_0 = (IPlugin)list_plugins.SelectedItem;
            try
            {
                IPlugin plugin = this.IPlugin_0;
                if (plugin == null)
                {
                    this.text_name.Text = "";
                    this.text_version.Text = "";
                    this.text_detail.Text = "";
                    this.checkbox_enabled.IsChecked = false;
                    this.checkbox_enabled.IsEnabled = false;
                }
                else
                {
                    this.text_name.Text = plugin.Author;
                    this.text_version.Text = plugin.Version;
                    this.text_detail.Text = plugin.Description;
                    this.checkbox_enabled.IsEnabled = true;
                    this.checkbox_enabled.IsChecked = new bool?(plugin.IsEnabled);
                }
            }
            catch (Exception exception)
            {
                ilog_0.Error("[Ui] An exception occurred:", exception);
            }
        }

        private void Checkbox_enabled_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    IPlugin plugin = this.IPlugin_0;
                    if (plugin == null)
                    {
                        System.Windows.MessageBox.Show("Please highlight the plugin you wish to enable or disable first, before clicking the checkbox.", "WpfApp1", MessageBoxButton.OK, MessageBoxImage.Hand);
                    }
                    else
                    {
                        //using (TritonHs.AcquireFrame())
                        {
                            PluginManager.Enable(plugin);
                        }
                        Globalsetting.Instance.EnabledPlugins = PluginManager.EnabledPlugins.Select<IPlugin, string>((Class25.plugin_name2 ?? (Class25.plugin_name2 = new Func<IPlugin, string>(Class25.abc.FindName2)))).ToList<string>();
                        //Configuration.Instance.SaveAll();
                    }
                }
            }
            catch (Exception exception)
            {
                ilog_0.Error("[Ui] An exception occurred:", exception);
            }
        }

        private void Checkbox_enabled_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                {
                    IPlugin plugin = this.IPlugin_0;
                    if (plugin == null)
                    {
                        System.Windows.MessageBox.Show("Please highlight the plugin you wish to enable or disable first, before clicking the checkbox.", "WpfApp1", MessageBoxButton.OK, MessageBoxImage.Hand);
                    }
                    else
                    {
                        //using (TritonHs.AcquireFrame())
                        {
                            PluginManager.Disable(plugin);
                        }
                        Globalsetting.Instance.EnabledPlugins = PluginManager.EnabledPlugins.Select<IPlugin, string>((Class25.plugin_name1 ?? (Class25.plugin_name1 = new Func<IPlugin, string>(Class25.abc.FindName1)))).ToList<string>();
                        //Configuration.Instance.SaveAll();
                    }
                }
            }
            catch (Exception exception)
            {
                ilog_0.Error("[Ui] An exception occurred:", exception);
            }
        }

        private void Load_UserControl(object object_0)
        {
            IAuthored authored = object_0 as IAuthored;
            if ((object_0 is IConfigurable configurable) && (authored != null))
            {
                System.Windows.Controls.UserControl control = configurable.Control;
                if (control != null)
                {
                    TabItem item1 = new TabItem
                    {
                        Header = authored.Name,
                        Content = control,
                        Tag = object_0
                    };
                    TabItem newItem = item1;
                    this.plugins_table.Items.Add(newItem);
                }
            }
        }

        private void Thread_TabItem(IPlugin iplugin_0)
        {
            base.Dispatcher.BeginInvoke(new Action(this.IPlugin_TabItem), Array.Empty<object>());
        }

        private void IPlugin_TabItem()
        {
            foreach (TabItem item2 in this.plugins_table.Items)
            {
                Class32 class2 = new Class32
                {
                    iplugin_0 = item2.Tag as IPlugin
                };
                if (class2.iplugin_0 != null)
                {
                    item2.Visibility = PluginManager.Plugins.First<IPlugin>(new Func<IPlugin, bool>(class2.Compare_Plugin)).IsEnabled ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            if ((this.plugins_table.SelectedItem is TabItem selectedItem) && (selectedItem.Visibility == Visibility.Collapsed))
            {
                this.plugins_table.SelectedIndex = 0;
            }
        }
        
        [CompilerGenerated]
        private IEnumerable Show_IPlugins()
        {
            IEnumerable enumerable;
            this.list_plugins.ItemsSource = enumerable = PluginManager.Plugins;
            return enumerable;
        }

        private void Thread_Load_Plugins()
        {
            foreach (IPlugin plugin in PluginManager.Plugins)
            {
                this.Load_UserControl(plugin);
            }
            this.IPlugin_TabItem();
        }

        [Serializable]
        private sealed class Class25
        {
            public static MainWindow.Class25 abc = new MainWindow.Class25();
            public static Func<IPlugin, string> plugin_name1;
            public static Func<IPlugin, string> plugin_name2;

            internal void Exit_Application()
            {
                System.Windows.Application.Current.Shutdown();
            }

            internal string FindName1(IPlugin iplugin_0) =>
                iplugin_0.Name;

            internal string FindName2(IPlugin iplugin_0) =>
                iplugin_0.Name;
        }
        
        private sealed class Class32
        {
            public IPlugin iplugin_0;

            internal bool Compare_Plugin(IPlugin iplugin_1) =>
                ReferenceEquals(iplugin_1, this.iplugin_0);
        }
    }
}
