using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using log4net;
using WpfApp1.Triton.Common;
using WpfApp1.Triton.Common.Plugins;
using Logger = WpfApp1.Triton.Common.LogUtilities.LogManagers;
namespace P114T5
{
    public class P114T5 : IPlugin
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private bool _enabled;

        private UserControl _control;

        #region Implementation of IPlugin

        public string Name
        {
            get
            {
                return "P114T5";
            }
        }

        public string Author
        {
            get
            {
                return "GSC HXZ WB";
            }
        }

        public string Description
        {
            get
            {
                return "The 5th topic On \"Introduction to Software Engineering\" Page 114.";
            }
        }

        public string Version
        {
            get
            {
                return "1.0";
            }
        }

        public UserControl Control
        {
            get
            {
                if (_control != null)
                {
                    return _control;
                }

                using (var fs = new FileStream(@"Plugins\P114T5\P114T5.xaml", FileMode.Open))
                {
                    var root = (System.Windows.Controls.UserControl)XamlReader.Load(fs);
                    // Your settings binding here.

                    // P1t1
                    if (
                        !Wpf.SetupTextBoxBinding(root, "p1t1",
                            "P1t1",
                            BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T5] SetupCheckBoxBinding failed for 'Year'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1t2
                    if (
                        !Wpf.SetupTextBoxBinding(root, "p1t2",
                            "P1t2",
                            BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T5] SetupCheckBoxBinding failed for 'Bit'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1t3
                    if (
                        !Wpf.SetupTextBoxBinding(root, "p1t3",
                            "P1t3",
                            BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T5] SetupCheckBoxBinding failed for 'Count_daily'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1t4
                    if (
                        !Wpf.SetupTextBoxBinding(root, "p1t4",
                            "P1t4",
                            BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T5] SetupCheckBoxBinding failed for 'Pay'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1t5
                    if (
                        !Wpf.SetupTextBoxBinding(root, "p1t5",
                            "Alltimes",
                            BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T5] SetupCheckBoxBinding failed for 'Day'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2t1
                    if (
                        !Wpf.SetupTextBoxBinding(root, "p2t1",
                            "P2t1",
                            BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T5] SetupCheckBoxBinding failed for 'Demand'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2t2
                    if (!Wpf.SetupTextBoxBinding(root, "p2t2", "P2t2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'Price'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // simulate
                    if (!Wpf.SetupTextBoxBinding(root, "simulate", "Timess",
                        BindingMode.TwoWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'Cost'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2t3
                    if (!Wpf.SetupTextBoxBinding(root, "p2t3", "P2t3",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopWinCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2t4
                    if (!Wpf.SetupTextBoxBinding(root, "p2t4", "P2t4",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t1c1
                    if (!Wpf.SetupTextBoxBinding(root, "t1c1", "T1c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t1c2
                    if (!Wpf.SetupTextBoxBinding(root, "t1c2", "T1c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t2c1
                    if (!Wpf.SetupTextBoxBinding(root, "t2c1", "T2c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t2c2
                    if (!Wpf.SetupTextBoxBinding(root, "t2c2", "T2c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t3c1
                    if (!Wpf.SetupTextBoxBinding(root, "t3c1", "T3c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t3c2
                    if (!Wpf.SetupTextBoxBinding(root, "t3c2", "T3c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t4c1
                    if (!Wpf.SetupTextBoxBinding(root, "t4c1", "T4c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t4c2
                    if (!Wpf.SetupTextBoxBinding(root, "t4c2", "T4c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t5c1
                    if (!Wpf.SetupTextBoxBinding(root, "t5c1", "T5c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t5c2
                    if (!Wpf.SetupTextBoxBinding(root, "t5c2", "T5c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1c1
                    if (!Wpf.SetupImageBinding(root, "p1c1", "P1c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'StopConcedeCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1c2
                    if (!Wpf.SetupImageBinding(root, "p1c2", "P1c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'RankTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1c3
                    if (!Wpf.SetupImageBinding(root, "p1c3", "P1c3",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'WinsTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2c1
                    if (!Wpf.SetupImageBinding(root, "p2c1", "P2c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'LossesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2c2
                    if (!Wpf.SetupImageBinding(root, "p2c2", "P2c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'ConcedesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2c3
                    if (!Wpf.SetupImageBinding(root, "p2c3", "P2c3",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T5] SetupTextBoxBinding failed for 'ConcedesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // Your settings event handlers here.
                    var resetButton = Wpf.FindControlByName<Button>(root, "ResetButton");
                    resetButton.Click += ResetButtonOnClick;

                    var addWinButton = Wpf.FindControlByName<Button>(root, "DealButton");
                    addWinButton.Click += DealButtonOnClick;

                    //var addLossButton = Wpf.FindControlByName<Button>(root, "AddLossButton");
                    //addLossButton.Click += AddLossButtonOnClick;

                    //var addConcedeButton = Wpf.FindControlByName<Button>(root, "AddConcedeButton");
                    //addConcedeButton.Click += AddConcedeButtonOnClick;

                    //var removeWinButton = Wpf.FindControlByName<Button>(root, "RemoveWinButton");
                    //removeWinButton.Click += RemoveWinButtonOnClick;

                    //var removeLossButton = Wpf.FindControlByName<Button>(root, "RemoveLossButton");
                    //removeLossButton.Click += RemoveLossButtonOnClick;

                    //var removeConcedeButton = Wpf.FindControlByName<Button>(root, "RemoveConcedeButton");
                    //removeConcedeButton.Click += RemoveConcedeButtonOnClick;

                    _control = root;
					
                }

                return _control;
            }
        }

        public JsonSettings Settings
        {
            get
            {
                return P114T5Settings.Instance;
            }
        }

        public void Disable()
        {
            Log.DebugFormat("[P114T5] Disable");
            _enabled = false;
        }

        public void Enable()
        {
            Log.DebugFormat("[P114T5] Enable");
            _enabled = true;
        }

        public bool IsEnabled
        {
            get { return _enabled; }
        }

        public void Initialize()
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void Tick()
        {
        }

        #endregion


        #region Implementation of IDisposable

        public void Deinitialize()
        {
        }

        #endregion


        #region Override of Object

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name + ": " + Description;
        }

        private void ResetButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            P114T5Settings.Instance.Reset();
        }

        private void DealButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            P114T5Settings.Instance.Drawcard();
        }

        #endregion

    }
}
