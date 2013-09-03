﻿using System;
using System.Windows;

namespace DesktopCS.Behaviors
{
    public class BindableDialogResult
    {
        public static readonly DependencyProperty DialogResultProperty =
            DependencyProperty.RegisterAttached("DialogResult", typeof (bool?), typeof (BindableDialogResult),
                new PropertyMetadata(null, OnDialogResultChanged));

        private static void OnDialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var wnd = d as Window;
            if (wnd == null)
                return;

            wnd.DialogResult = (bool?)e.NewValue;
        }

        public static bool? GetDialogResult(DependencyObject dp)
        {
            if (dp == null) throw new ArgumentNullException("dp");

            return (bool?)dp.GetValue(DialogResultProperty);
        }

        public static void SetDialogResult(DependencyObject dp, object value)
        {
            if (dp == null) throw new ArgumentNullException("dp");

            dp.SetValue(DialogResultProperty, value);
        }
    }
}
