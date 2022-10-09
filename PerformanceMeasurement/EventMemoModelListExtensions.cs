using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMeasurement
{
    public static class EventMemoModelListExtensions
    {
        public static string ReturningMark(this List<EventMemoModel> events, string text)
        {
            var memo = EventMemoModels.Now(text);
            events.Add(memo);
            if (events.Count > 1)
            {
                var previous = events[events.Count - 2];
                var elapsed = (memo.Utc - previous.Utc).TotalMilliseconds;
                var elapsedString = $"{(int)elapsed} ms {memo.Text}";
                return elapsedString;
            }
            return "";
        }

        public static void Mark(this List<EventMemoModel> events, string text)
        {
            var memo = EventMemoModels.Now(text);
            events.Add(memo);
        }

        private static string FormatMilliseconds(int ms)
        {
            return ms.ToString("N0");
        }

        private static string FormatMilliseconds(double ms)
        {
            int roundedMs = (int)Math.Round(ms);
            return FormatMilliseconds(roundedMs);
        }

        public static string ToMultilineString(this List<EventMemoModel> list, bool includeTotalLine = true)
        {
            var builder = new StringBuilder();
            var previous = DateTime.MinValue;
            var maxLength = list.Select(e => e.Text.Length).Max();
            foreach (var eventMemo in list)
            {
                if (previous != DateTime.MinValue)
                {
                    var elapsed = (eventMemo.Utc - previous).TotalMilliseconds;
                    var roundedTime = FormatMilliseconds(elapsed);
                    builder.AppendLine($"{eventMemo.Text.PadRight(maxLength + 1)}{roundedTime}");
                }
                previous = eventMemo.Utc;
            }
            var r = builder.ToString();
            return r;
        }
    }
}
