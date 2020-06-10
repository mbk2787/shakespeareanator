namespace Shakespeareanator.Utils
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;
    using System;

    /// <summary>
    /// The JSON extension methods.
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// The default json formatting
        /// </summary>
        public static readonly Formatting DefaultJsonFormatting = Formatting.Indented;

        /// <summary>
        /// The default json serializer settings
        /// </summary>
        public static readonly JsonSerializerSettings DefaultJsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new JsonConverter[] { new StringEnumConverter() },
            TypeNameHandling = TypeNameHandling.Auto,
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatHandling = DateFormatHandling.IsoDateFormat
        };

        public static readonly JsonSerializerSettings EasyJsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new JsonConverter[] { new StringEnumConverter() },
            TypeNameHandling = TypeNameHandling.None,
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatHandling = DateFormatHandling.IsoDateFormat
        };

        /// <summary>
        /// Determines whether [is valid json].
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static bool IsValidJson(this string json)
        {
            try
            {
                json.ParseJson();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Parses the json.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static bool IsValidJson<T>(this string json)
        {
            try
            {
                json.ParseJson<T>();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Parses the json string into a <see cref="System.Dynamic.DynamicObject"/>.
        /// </summary>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static dynamic ParseJson(this string json) => JsonConvert.DeserializeObject(json, DefaultJsonSerializerSettings);

        /// <summary>
        /// Parses the json string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json">The json.</param>
        /// <returns></returns>
        public static T ParseJson<T>(this string json) => JsonConvert.DeserializeObject<T>(json, DefaultJsonSerializerSettings);

        /// <summary>
        /// To the json.
        /// </summary>
        /// <param name="object">The object.</param>
        /// <param name="formatting">The formatting.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <returns></returns>
        public static string ToJson(this object @object, Formatting formatting, JsonSerializerSettings serializerSettings) => JsonConvert.SerializeObject(@object, formatting, serializerSettings);

        /// <summary>
        /// To the json, use camelcase for properties, enum are stringyfieds and $type is added
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public static string ToJson(this object @object) => JsonConvert.SerializeObject(@object, DefaultJsonFormatting, DefaultJsonSerializerSettings);

        /// <summary>
        /// Parses the object to json without adding the $type field
        /// </summary>
        /// <param name="object">The object.</param>
        /// <returns></returns>
        public static string ToEasyJson(this object @object) => JsonConvert.SerializeObject(@object, DefaultJsonFormatting, EasyJsonSerializerSettings);
    }
}