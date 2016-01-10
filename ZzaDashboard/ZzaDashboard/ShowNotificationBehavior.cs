﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace ZzaDashboard
{
    public class ShowNotificationBehavior : Behavior<ContentControl>
    {



        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(ShowNotificationBehavior), new PropertyMetadata(null, OnMessageChanged));

        private static void OnMessageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as ShowNotificationBehavior;

            behavior.AssociatedObject.Content = e.NewValue;
            behavior.AssociatedObject.Visibility = Visibility.Visible;
        }

        protected override void OnAttached()
        {
            AssociatedObject.PreviewMouseLeftButtonDown += (s, e) =>
            {
                AssociatedObject.Visibility = Visibility.Collapsed;
            };
        }
    }
}
