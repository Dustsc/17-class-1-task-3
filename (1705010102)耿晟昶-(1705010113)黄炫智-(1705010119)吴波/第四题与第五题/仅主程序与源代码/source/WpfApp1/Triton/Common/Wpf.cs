using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WpfApp1.Triton.Common
{
    using System;
    using System.Collections;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;

    public static class Wpf
    {
        public static T FindControlByName<T>(System.Windows.FrameworkElement root, string name) where T : class =>
            (smethod_0(root, name) as T);

        public static bool SetupCheckBoxBinding(System.Windows.FrameworkElement xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
        {
            CheckBox box = FindControlByName<CheckBox>(xamlRoot, controlName);
            if (box == null)
            {
                return false;
            }
            Binding binding1 = new Binding(bindingName);
            binding1.Mode = bindingMode;
            binding1.Source = bindingSource;
            binding1.Converter = converter;
            Binding binding = binding1;
            box.SetBinding(ToggleButton.IsCheckedProperty, binding);
            return true;
        }

        public static bool SetupImageBinding(System.Windows.FrameworkElement xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
        {
            Image box = FindControlByName<Image>(xamlRoot, controlName);
            if (box == null)
            {
                return false;
            }
            Binding binding1 = new Binding(bindingName);
            binding1.Mode = bindingMode;
            binding1.Source = bindingSource;
            binding1.Converter = converter;
            Binding binding = binding1;
            box.SetBinding(Image.SourceProperty, binding);
            return true;
        }

        public static bool SetupComboBoxItemsBinding(System.Windows.FrameworkElement xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
        {
            ComboBox box = FindControlByName<ComboBox>(xamlRoot, controlName);
            if (box == null)
            {
                return false;
            }
            Binding binding1 = new Binding(bindingName);
            binding1.Mode = bindingMode;
            binding1.Source = bindingSource;
            binding1.Converter = converter;
            Binding binding = binding1;
            box.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            return true;
        }

        public static bool SetupComboBoxSelectedItemBinding(System.Windows.FrameworkElement xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
        {
            ComboBox box = FindControlByName<ComboBox>(xamlRoot, controlName);
            if (box == null)
            {
                return false;
            }
            Binding binding1 = new Binding(bindingName);
            binding1.Mode = bindingMode;
            binding1.Source = bindingSource;
            binding1.Converter = converter;
            Binding binding = binding1;
            box.SetBinding(Selector.SelectedItemProperty, binding);
            return true;
        }

        public static bool SetupLabelBinding(System.Windows.FrameworkElement xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
        {
            Label label = FindControlByName<Label>(xamlRoot, controlName);
            if (label == null)
            {
                return false;
            }
            Binding binding1 = new Binding(bindingName);
            binding1.Mode = bindingMode;
            binding1.Source = bindingSource;
            binding1.Converter = converter;
            Binding binding = binding1;
            label.SetBinding(ContentControl.ContentProperty, binding);
            return true;
        }

        public static bool SetupListBoxItemsBinding(System.Windows.FrameworkElement xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
        {
            ListBox box = FindControlByName<ListBox>(xamlRoot, controlName);
            if (box == null)
            {
                return false;
            }
            Binding binding1 = new Binding(bindingName);
            binding1.Mode = bindingMode;
            binding1.Source = bindingSource;
            binding1.Converter = converter;
            Binding binding = binding1;
            box.SetBinding(ItemsControl.ItemsSourceProperty, binding);
            return true;
        }

        public static bool SetupListBoxSelectedItemBinding(System.Windows.FrameworkElement xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
        {
            ListBox box = FindControlByName<ListBox>(xamlRoot, controlName);
            if (box == null)
            {
                return false;
            }
            Binding binding1 = new Binding(bindingName);
            binding1.Mode = bindingMode;
            binding1.Source = bindingSource;
            binding1.Converter = converter;
            Binding binding = binding1;
            box.SetBinding(Selector.SelectedItemProperty, binding);
            return true;
        }

        public static bool SetupTextBoxBinding(System.Windows.FrameworkElement xamlRoot, string controlName, string bindingName, BindingMode bindingMode, object bindingSource, IValueConverter converter = null)
        {
            TextBox box = (TextBox)xamlRoot.FindName(controlName);
            if (box == null)
            {
                return false;
            }
            Binding binding1 = new Binding(bindingName)
            {
                Mode = bindingMode,
                Source = bindingSource,
                Converter = converter
            };
            box.SetBinding(TextBox.TextProperty, binding1);
            return true;
        }

        private static System.Windows.FrameworkElement smethod_0(System.Windows.FrameworkElement dependencyObject_0, string string_0)
        {
            if (dependencyObject_0 == null)
            {
                return null;
            }
            System.Windows.FrameworkElement obj2 = (System.Windows.FrameworkElement)dependencyObject_0.FindName(string_0);
            if (obj2 != null)
            {
                return obj2;
            }
            return null;
        }
    }
}