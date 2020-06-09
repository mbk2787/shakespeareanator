namespace Shakespeareanator.Pokemon
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Globalization;

    public partial class PokemonSpeciesDto
    {
        [JsonProperty("base_happiness")]
        public long BaseHappiness { get; set; }

        [JsonProperty("capture_rate")]
        public long CaptureRate { get; set; }

        [JsonProperty("color")]
        public Color Color { get; set; }

        [JsonProperty("egg_groups")]
        public Color[] EggGroups { get; set; }

        [JsonProperty("evolution_chain")]
        public EvolutionChain EvolutionChain { get; set; }

        [JsonProperty("evolves_from_species")]
        public Color EvolvesFromSpecies { get; set; }

        [JsonProperty("flavor_text_entries")]
        public FlavorTextEntry[] FlavorTextEntries { get; set; }

        [JsonProperty("form_descriptions")]
        public object[] FormDescriptions { get; set; }

        [JsonProperty("forms_switchable")]
        public bool FormsSwitchable { get; set; }

        [JsonProperty("gender_rate")]
        public long GenderRate { get; set; }

        [JsonProperty("genera")]
        public Genus[] Genera { get; set; }

        [JsonProperty("generation")]
        public Color Generation { get; set; }

        [JsonProperty("growth_rate")]
        public Color GrowthRate { get; set; }

        [JsonProperty("habitat")]
        public Color Habitat { get; set; }

        [JsonProperty("has_gender_differences")]
        public bool HasGenderDifferences { get; set; }

        [JsonProperty("hatch_counter")]
        public long HatchCounter { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_baby")]
        public bool IsBaby { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("names")]
        public Name[] Names { get; set; }

        [JsonProperty("order")]
        public long Order { get; set; }

        [JsonProperty("pal_park_encounters")]
        public PalParkEncounter[] PalParkEncounters { get; set; }

        [JsonProperty("pokedex_numbers")]
        public PokedexNumber[] PokedexNumbers { get; set; }

        [JsonProperty("shape")]
        public Color Shape { get; set; }

        [JsonProperty("varieties")]
        public Variety[] Varieties { get; set; }
    }

    public partial class Color
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class EvolutionChain
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public partial class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }

        [JsonProperty("language")]
        public Color Language { get; set; }

        [JsonProperty("version")]
        public Color Version { get; set; }
    }

    public partial class Genus
    {
        [JsonProperty("genus")]
        public string GenusGenus { get; set; }

        [JsonProperty("language")]
        public Color Language { get; set; }
    }

    public partial class Name
    {
        [JsonProperty("language")]
        public Color Language { get; set; }

        [JsonProperty("name")]
        public string NameName { get; set; }
    }

    public partial class PalParkEncounter
    {
        [JsonProperty("area")]
        public Color Area { get; set; }

        [JsonProperty("base_score")]
        public long BaseScore { get; set; }

        [JsonProperty("rate")]
        public long Rate { get; set; }
    }

    public partial class PokedexNumber
    {
        [JsonProperty("entry_number")]
        public long EntryNumber { get; set; }

        [JsonProperty("pokedex")]
        public Color Pokedex { get; set; }
    }

    public partial class Variety
    {
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }

        [JsonProperty("pokemon")]
        public Color Pokemon { get; set; }
    }

    public partial class PokemonSpeciesDto
    {
        public static PokemonSpeciesDto FromJson(string json) => JsonConvert.DeserializeObject<PokemonSpeciesDto>(json, Shakespeareanator.Pokemon.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this PokemonSpeciesDto self) => JsonConvert.SerializeObject(self, Shakespeareanator.Pokemon.Converter.Settings);
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