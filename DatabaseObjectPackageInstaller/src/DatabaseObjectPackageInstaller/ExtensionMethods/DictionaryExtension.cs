using System.Collections.Generic;
using DatabaseObjectPackageInstaller.Constants;


namespace DatabaseObjectPackageInstaller.ExtensionMethods
{
    public static class DictionaryExtension
    {
        public static void AddOrAppend<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue value)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = (TValue)(object)string.Format(ResourceStrings.ErrorAppender, dict[key], value);
            }
            else
            {
                dict.Add(key, value);
            }
        }
    }
}
