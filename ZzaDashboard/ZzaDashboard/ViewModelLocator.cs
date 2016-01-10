using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ZzaDashboard
{
    public static class ViewModelLocator
    {

        public static bool GetAutoWiredViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(WiredViewModelProperty);
        }

        public static void SetAutoWiredViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(WiredViewModelProperty, value);
        }

        // Using a DependencyProperty as the backing store for WiredViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WiredViewModelProperty =
            DependencyProperty.RegisterAttached("AutoWiredViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoWiredViewModelChanged));

        private static void AutoWiredViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d)) return;

            var viewTypeName = d.GetType().FullName;

            var viewModelType = Type.GetType(viewTypeName + "Model");

            var viewModel = Activator.CreateInstance(viewModelType);

            ((FrameworkElement)d).DataContext = viewModel;
        }
    }
}
