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

namespace WpfApp1.Plugins.P114T4
{
    public class P114T4 : IPlugin
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();

        private bool _enabled;

        private UserControl _control;

        #region Implementation of IPlugin

        public string Name
        {
            get
            {
                return "P114T4";
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
                return "The 4th topic On \"Introduction to Software Engineering\" Page 114.";
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

                using (var fs = new FileStream(@"Plugins\P114T4\P114T4.xaml", FileMode.Open))
                {
                    var root = (System.Windows.Controls.UserControl)XamlReader.Load(fs);
                    // Your settings binding here.

                    // Path
                    if (
                        !Wpf.SetupTextBoxBinding(root, "paths",
                            "Path",
                            BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T4] SetupCheckBoxBinding failed for 'Year'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // Wage
                    if (
                        !Wpf.SetupTextBoxBinding(root, "wages",
                            "Wage",
                            BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T4] SetupCheckBoxBinding failed for 'Bit'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // age
                    if (
                        !Wpf.SetupTextBoxBinding(root, "ages",
                            "Age",
                            BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T4] SetupCheckBoxBinding failed for 'Count_daily'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // number
                    if (
                        !Wpf.SetupTextBoxBinding(root, "numbers",
                            "Number",
                            BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T4] SetupCheckBoxBinding failed for 'Pay'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    //person
                    if (
                        !Wpf.SetupTextBoxBinding(root, "persons",
                            "Person",
                            BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T4] SetupCheckBoxBinding failed for 'Day'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // perage
                    if (
                        !Wpf.SetupTextBoxBinding(root, "perages",
                            "Perage",
                            BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat(
                            "[P114T4] SetupCheckBoxBinding failed for 'Demand'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // name
                    if (!Wpf.SetupTextBoxBinding(root, "names", "Names",
                        BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'Price'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // label1
                    if (!Wpf.SetupLabelBinding(root, "Lines1", "labelstext",
                        BindingMode.OneWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'Cost'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // label2
                    if (!Wpf.SetupLabelBinding(root, "Lines2", "labelstext",
                        BindingMode.OneWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopWinCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // label3
                    if (!Wpf.SetupLabelBinding(root, "Lines3", "labelstext",
                        BindingMode.OneWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // lable4
                    if (!Wpf.SetupLabelBinding(root, "Lines4", "labelstext",
                        BindingMode.OneWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // below
                    if (!Wpf.SetupTextBoxBinding(root, "belows", "Below",
                        BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // row
                    if (!Wpf.SetupCheckBoxBinding(root, "row", "Rowcol1",
                        BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // col
                    if (!Wpf.SetupCheckBoxBinding(root, "col", "Rowcol2",
                        BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // method1
                    if (!Wpf.SetupCheckBoxBinding(root, "method1", "Methods1",
                        BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // method2
                    if (!Wpf.SetupCheckBoxBinding(root, "method2", "Methods2",
                        BindingMode.TwoWay, P114T4Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }
                    /*
                    // t4c1
                    if (!Wpf.SetupTextBoxBinding(root, "t4c1", "T4c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t4c2
                    if (!Wpf.SetupTextBoxBinding(root, "t4c2", "T4c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t5c1
                    if (!Wpf.SetupTextBoxBinding(root, "t5c1", "T5c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // t5c2
                    if (!Wpf.SetupTextBoxBinding(root, "t5c2", "T5c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopLossCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1c1
                    if (!Wpf.SetupImageBinding(root, "p1c1", "P1c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'StopConcedeCountTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1c2
                    if (!Wpf.SetupImageBinding(root, "p1c2", "P1c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'RankTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p1c3
                    if (!Wpf.SetupImageBinding(root, "p1c3", "P1c3",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'WinsTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2c1
                    if (!Wpf.SetupImageBinding(root, "p2c1", "P2c1",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'LossesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2c2
                    if (!Wpf.SetupImageBinding(root, "p2c2", "P2c2",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'ConcedesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }

                    // p2c3
                    if (!Wpf.SetupImageBinding(root, "p2c3", "P2c3",
                        BindingMode.OneWay, P114T5Settings.Instance))
                    {
                        Log.DebugFormat("[P114T4] SetupTextBoxBinding failed for 'ConcedesTextBox'.");
                        throw new Exception("The SettingsControl could not be created.");
                    }*/

                    // Your settings event handlers here.
                    var resetButton = Wpf.FindControlByName<Button>(root, "openfiles");
                    resetButton.Click += openButtonOnClick;

                    var addWinButton = Wpf.FindControlByName<Button>(root, "savefiles");
                    addWinButton.Click += saveButtonOnClick;

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
                return P114T4Settings.Instance;
            }
        }

        public void Disable()
        {
            Log.DebugFormat("[P114T4] Disable");
            _enabled = false;
        }

        public void Enable()
        {
            Log.DebugFormat("[P114T4] Enable");
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

        private void openButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            P114T4Settings.Instance.openfile();
        }

        private void saveButtonOnClick(object sender, RoutedEventArgs routedEventArgs)
        {
            P114T4Settings.Instance.savefile();
        }

        #endregion

    }
}
