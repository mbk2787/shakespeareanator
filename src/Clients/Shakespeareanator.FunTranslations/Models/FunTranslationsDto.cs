namespace Shakespeareanator.FunTranslations
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FunTranslationsDto
    {
        [JsonProperty("success")]
        public Success Success { get; set; }

        [JsonProperty("contents")]
        public Contents Contents { get; set; }
    }

    public partial class Contents
    {
        [JsonProperty("translated")]
        public string Translated { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("translation")]
        public string Translation { get; set; }
    }

    public partial class Success
    {
        [JsonProperty("total")]
        public long Total { get; set; }
    }

    public partial class FunTranslationsDto
    {
        public static FunTranslationsDto FromJson(string json) => JsonConvert.DeserializeObject<FunTranslationsDto>(json, Shakespeareanator.FunTranslations.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this FunTranslationsDto self) => JsonConvert.SerializeObject(self, Shakespeareanator.FunTranslations.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
