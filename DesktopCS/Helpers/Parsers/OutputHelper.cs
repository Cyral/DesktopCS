﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows.Media;

namespace DesktopCS.Helpers.Parsers
{
    class OutputHelper
    {
        public static Span Parse(string text, Color foreground)
        {
            var newText = InputHelper.Parse(text);
            return MIRCHelper.Parse(newText, foreground);
        }
    }
}