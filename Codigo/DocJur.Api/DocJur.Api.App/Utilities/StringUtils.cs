using Newtonsoft.Json;
using System;
using System.Text;
using System.Xml;

namespace DocJur.Api.App.Utilities
{
    /// <summary>
    /// Extensions and utilities methods to ease the coding with string types.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Checks if a string is null or length == 0.
        /// Invoking <c>StringUtils.IsEmpty("")</c> returns true.
        /// Invoking <c>StringUtils.IsEmpty(null)</c> returns true.
        /// Invoking <c>StringUtils.IsEmpty(" ")</c> returns false.
        /// </summary>
        /// <param name="value">A <c>string</c> to be checked.</param>
        /// <returns>True if the string is null or has length == 0.</returns>
        public static bool IsEmpty(this string value) => value == null || value.Length == 0;

        /// <summary>
        /// Checks if the string value is null before call the Replace method.
        /// If the value is null, returns the dafault value (if provided).
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of oldValue.</param>
        /// <param name="defaultValue">The default value returned in case the value is null.</param>
        /// <returns>
        /// If the string is null the defaultValue is returned, otherwise a string that is equivalent to the current
        /// string except that all instances of oldValue are replaced with newValue. If oldValue is not found in the current
        /// instance, the method returns the current instance unchanged.
        /// </returns>
        public static string SafeReplace(this string value, string oldValue, string newValue, string defaultValue = null) => value != null ? value.Replace(oldValue, newValue) : defaultValue;

        /// <summary>
        /// Returns a value indicating whether one of the specified substrings occurs within this string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="substrings"></param>
        /// <returns></returns>
        public static bool ContainsAny(this string value, params string[] substrings)
        {
            foreach (string substring in substrings)
            {
                if (value.Contains(substring))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// If the string is a number, parse it to remove the Leading zeros, otherwise returns the original string.
        /// </summary>
        /// <param name="value">String to cleaned.</param>
        public static string RemoveLeadingZeros(this string value)
        {
            if (long.TryParse(value, out long result))
            {
                return result.ToString();
            }

            return value;
        }

        /// <summary>
        /// Converts a string value in a Json or XML format into a Dynamic object.
        /// </summary>
        /// <param name="value">The string value in Json or XML format.</param>
        /// <param name="dynamicType">The string format (default null, auto detect).</param>
        /// <returns></returns>
        public static dynamic Dynamic(this string value, string dynamicType = null)
        {
            if (value == null)
            {
                return null;
            }

            if (dynamicType == null)
            {
                if (value.TrimStart().StartsWith("{"))
                {
                    dynamicType = "Json";
                }
                else if (value.TrimStart().StartsWith("<"))
                {
                    dynamicType = "XML";
                }
                else
                {
                    throw new NotSupportedException("Only Json or XML strings are supported.");
                }
            }

            if (dynamicType.Equals("Json", StringComparison.OrdinalIgnoreCase))
            {
                return JsonConvert.DeserializeObject<dynamic>(value);
            }
            else if (dynamicType.Equals("XML", StringComparison.OrdinalIgnoreCase))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(value);
                string json = JsonConvert.SerializeXmlNode(xmlDocument);
                return JsonConvert.DeserializeObject<dynamic>(json);
            }

            throw new NotSupportedException();
        }

        /// <summary>
        /// Remove Diacritics from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string value)
        {
            if (value == null)
            {
                return null;
            }
            else if (value.Length == 0)
            {
                return value;
            }

            char[] diacritics = new char[] { 'á','é','í','ó','ú','à','è','ì','ò','ù','â','ê','î','ô','û','ã','õ','ç',
                                             'Á','É','Í','Ó','Ú','À','È','Ì','Ò','Ù','Â','Ê','Î','Ô','Û','Ã','Õ','Ç'};

            char[] normal = new char[] { 'a','e','i','o','u','a','e','i','o','u','a','e','i','o','u','a','o','c',
                                         'A','E','I','O','U','A','E','I','O','U','A','E','I','O','U','A','O','C',};

            StringBuilder sb = new StringBuilder(value);

            for (int i = 0; i < diacritics.Length; i++)
            {
                sb.Replace(diacritics[i], normal[i]);
            }

            value = sb.ToString();
            return value;
        }
    }
}
