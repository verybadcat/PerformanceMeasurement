using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformanceMeasurement
{
    public static class EventMemoModelLists
    {
        private static Dictionary<object, List<EventMemoModel>> Instances
            = new Dictionary<object, List<EventMemoModel>>();

        public static List<EventMemoModel> StartingNow()
        {
            var list = new List<EventMemoModel>();
            list.Mark("");
            return list;
        }

        public static List<EventMemoModel> GetInstance(object key)
        {
            if (!Instances.ContainsKey(key))
            {
                Instances[key] = StartingNow();
            }
            return Instances[key];
        }

        public static List<EventMemoModel> GetNewInstance(object key)
        {
            if (Instances.ContainsKey(key))
            {
                Instances.Remove(key);
            }
            return GetInstance(key);
        }

        public static List<EventMemoModel> Default => GetInstance("Default");
    }
}
