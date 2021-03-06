﻿using System.Windows;
using System.Windows.Documents;
using DesktopCS.Helpers;
using DesktopCS.Helpers.Parsers;

namespace DesktopCS.Behaviors
{
    internal class MIRC
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.RegisterAttached(
            "Text",
            typeof (string),
            typeof (MIRC),
            new PropertyMetadata(null, OnTextChanged)
            );

        public static string GetText(DependencyObject d)
        {
            return d.GetValue(TextProperty) as string;
        }

        public static void SetText(DependencyObject d, string value)
        {
            d.SetValue(TextProperty, value);
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBlock = d as Span;
            if (textBlock == null)
                return;

            textBlock.Inlines.Clear();

            var newText = (string)e.NewValue;
            if (string.IsNullOrEmpty(newText))
                return;

            var args = new ParseArgs(ColorHelper.MessageColor, false, false);
            textBlock.Inlines.Add(OutputHelper.Parse(newText, args));
        }
    }
}