using System.Collections.Generic;

namespace RHost
{
    public static class FdkVars
    {
        public static Dictionary<string, object> Vars = new Dictionary<string, object>();
        public static string RegisterVariable(object data, string prefix)
        {
            var pos = 0;
            if (string.IsNullOrEmpty(prefix))
                prefix = "fdk_";
            while (Vars.ContainsKey(string.Format("{0}_{1}", prefix, pos)))
            {
                pos++;
            }
            var varName = string.Format("{0}_{1}", prefix, pos);
            Vars[varName] = data;
            return varName;
        }

        public static void Unregister(string varName)
        {
            Vars.Remove(varName);
        }

        public static T GetValue<T>(string varName)
        {
            object result;
            if (!Vars.TryGetValue(varName, out result))
                return default(T);
            return (T) result;
        }
    }
}