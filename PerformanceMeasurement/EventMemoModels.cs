using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMeasurement
{
    public static class EventMemoModels
    {
        public static EventMemoModel Now(string text)
        {
            var memo = new EventMemoModel
            {
                Text = text,
                Utc = DateTime.UtcNow,
            };
            return memo;
        }
    }
}
