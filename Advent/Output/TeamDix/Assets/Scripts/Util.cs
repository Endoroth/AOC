using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class Util
    {


        public static string FormatTimeDifference(TimeSpan span, bool dotEnd = true)
        {
            var output = string.Empty;
            if (span.Days > 0)
                output += span.Days + "d ";
            if (span.Hours > 0)
                output += span.Hours + "h ";
            if (span.Minutes > 0)
                output += span.Minutes + "m ";
            if (span.Seconds > 0)
                output += span.Seconds + "s ";
            if (span.Milliseconds > 0)
                output += span.Milliseconds + "ms";

            if (!string.IsNullOrEmpty(output) && dotEnd)
                output += ".";

            return string.IsNullOrEmpty(output) ? "" : output.TrimEnd(' ');
        }
    }
}
