using System;
using System.Collections.Generic;

namespace JustR.Core.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key, Func<TValue> valueCreator)
        {
            if (!dictionary.TryGetValue(key, out TValue value))
            {
                value = valueCreator.Invoke();
                dictionary.Add(key, value);
            }

            return value;
        }

        public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key) where TValue : new()
        {
            return GetOrAdd(dictionary, key, () => new TValue());
        }
    }
}