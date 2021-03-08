using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace DocJur.Api.App.Utilities
{
    /// <summary>
    /// Extensions and utilities methods to ease the coding with collection types.
    /// </summary>
    public static class CollectionsUtils
    {
        /// <summary>
        /// Checks if the IDictionary is null or has Count == 0.
        /// </summary>
        /// <typeparam name="K">The type of the key.</typeparam>
        /// <typeparam name="V">The type of the values in the dictionary.</typeparam>
        /// <param name="dictionary">The dictionary instance.</param>
        /// <returns>True if the dictionary is null or empty.</returns>
        public static bool IsEmpty<K, V>(this IDictionary<K, V> dictionary) => dictionary == null || dictionary.Count == 0;

        /// <summary>
        /// Checks if the IList is null or has Count == 0.
        /// </summary>
        /// <typeparam name="T">The type of the values in the list.</typeparam>
        /// <param name="list"></param>
        /// <returns>True if the list is null or empty.</returns>
        public static bool IsEmpty<T>(this IList<T> list) => list == null || list.Count == 0;

        /// <summary>
        /// Gets a value from the NameValueCollection and provide ways to handle missing keys.
        /// </summary>
        /// <typeparam name="T">The type the value should be converted to.</typeparam>
        /// <param name="collection">The instance collection.</param>
        /// <param name="key">The System.String key of the entry to locate. The key can be null.</param>
        /// <param name="defaultValue">The default value that will be returned if no settings was defined.</param>
        /// <param name="throwIfNotDefined">If true will throw and BliveExeption if settings was defined, otherwise the defaultValue is returned.</param>
        /// <returns></returns>
        public static T Get<T>(this NameValueCollection collection, string key, T defaultValue, bool throwIfNotDefined = false)
        {
            key.RequireNonNull("Key cannot be null");

            string stringValue = collection[key];

            if (stringValue == null)
            {
                if (throwIfNotDefined)
                {
                    throw new DocJurException($"Missing settings '{key}'. Check the App.Config file.");
                }

                return defaultValue;
            }

            try
            {
                T value = (T)Convert.ChangeType(stringValue, typeof(T));
                return value;
            }
            catch (Exception e)
            {
                throw new DocJurException($"The setting '{key}={stringValue}' cannot be converted to {typeof(T).Name}. Check the the App.Config file. {e.Message}");
            }
        }

        /// <summary>
        /// Performs an action for each element of this dictionary.
        /// </summary>
        /// <typeparam name="K">The type of keys in the dictionary</typeparam>
        /// <typeparam name="V">The type of values in the dictionary</typeparam>
        /// <param name="dictionary">The dictionary instance to perform an action.</param>
        /// <param name="action">A non-interfering action to perform on the elements.</param>
        public static void ForEach<K, V>(this IDictionary<K, V> dictionary, Action<KeyValuePair<K, V>> action)
        {
            foreach (KeyValuePair<K, V> kvp in dictionary)
            {
                action.Invoke(kvp);
            }
        }

        /// <summary>
        /// Performs an action for each element of this collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <param name="collection">The collection instance to perform an action.</param>
        /// <param name="action">A non-interfering action to perform on the elements.</param>
        public static void ForEach<T>(this ICollection<T> collection, Action<T> action)
        {
            foreach (T item in collection)
            {
                action.Invoke(item);
            }
        }
    }
}
