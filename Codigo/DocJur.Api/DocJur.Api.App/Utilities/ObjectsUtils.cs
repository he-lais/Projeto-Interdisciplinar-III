using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DocJur.Api.App.Utilities
{
    /// <summary>
    /// Extensions and utilities methods to ease the coding with object types.
    /// </summary>
    public static class ObjectsUtils
    {
        /// <summary>
        /// Checks that the specified object reference is not null.
        /// This method is designed primarily for doing parameter validation in methods and constructors.
        /// </summary>
        /// <param name="value">The reference to check for nullity.</param>
        /// <param name="exceptionMessage">The message that describes the error.</param>
        public static void RequireNonNull(this object value, string exceptionMessage)
        {
            if (value == null)
            {
                throw new ArgumentException(exceptionMessage);
            }
        }

        /// <summary>
        /// Returns the result of calling ToString on the first argument if the first argument is not null and returns the second argument otherwise.
        /// </summary>
        /// <param name="value">The value to return as string representation.</param>
        /// <param name="nullDefault">The string to return if the value is null. (optional, default 'null')</param>
        /// <returns>The result of calling ToString on the first argument if it is not null and the second argument otherwise.</returns>
        public static string ToString(object value, string nullDefault = "null") => value != null ? value.ToString() : nullDefault;

        /// <summary>
        /// Get type name without tilde.
        /// </summary>
        /// <param name="type">The type instance.</param>
        /// <returns></returns>
        public static string GetName(this Type type) => type.Name.Replace("`1", string.Empty);

        /// <summary>
        /// Remove all Diacritics from strings values of the entity and nested ones.
        /// </summary>
        /// <param name="entity"></param>
        public static void RemoveDiacriticsFromStrings(this object entity)
        {
            IList<PropertyInfo> properties = entity.GetType().GetProperties().ToList();

            foreach (PropertyInfo property in properties)
            {
                if (!property.CanWrite)
                {
                    continue;
                }

                object value = property.GetValue(entity, null);

                if (value == null)
                {
                    continue;
                }

                Type propertyType = property.PropertyType;

                if (propertyType == typeof(string))
                {
                    value = ((string)value).RemoveDiacritics();
                    property.SetValue(entity, value);

                }
                else if (propertyType.IsArray || typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    System.Collections.IEnumerable e = (System.Collections.IEnumerable)value;

                    foreach (object item in e)
                    {
                        RemoveDiacriticsFromStrings(item);
                    }
                }
                else if (!propertyType.FullName.StartsWith("System."))
                {
                    RemoveDiacriticsFromStrings(value);
                }
            }
        }

        /// <summary>
        /// Returns the Json PropertyName value.
        /// </summary>
        /// <param name="value">Object to get JsonProperty Name.</param>
        /// <param name="property">Object's property name.</param>
        /// <returns>The Json PropertyName value.</returns>
        public static string GetJsonPropertyName(this object value, string property) => value.GetType().GetProperty(property).GetCustomAttribute<JsonPropertyAttribute>().PropertyName;
    }
}
