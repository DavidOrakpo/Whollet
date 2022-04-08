﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Whollet.Model.APIModels;
//
//    var cryptoLogo = CryptoLogo.FromJson(jsonString);

namespace Whollet.Model.APIModels
{
    using System;
    using System.Collections.Generic;
    using Whollet.Model.APIModels;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class CryptoLogo
    {
        [JsonProperty("status")]
        public Status Status { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, Datum> Data { get; set; }
    }

    public partial class Datum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("logo")]
        public Uri Logo { get; set; }

        [JsonProperty("subreddit")]
        public string Subreddit { get; set; }

        [JsonProperty("tag-names")]
        public string[] TagNames { get; set; }

        [JsonProperty("tag-groups")]
        public TagGroup[] TagGroups { get; set; }

        [JsonProperty("twitter_username")]
        public string TwitterUsername { get; set; }

        [JsonProperty("is_hidden")]
        public long IsHidden { get; set; }

        [JsonProperty("date_launched")]
        public object DateLaunched { get; set; }

        [JsonProperty("contract_address")]
        public ContractAddress[] ContractAddress { get; set; }

        [JsonProperty("self_reported_circulating_supply")]
        public object SelfReportedCirculatingSupply { get; set; }

        [JsonProperty("self_reported_tags")]
        public object SelfReportedTags { get; set; }

        [JsonProperty("self_reported_market_cap")]
        public object SelfReportedMarketCap { get; set; }
    }

    public partial class ContractAddress
    {
        [JsonProperty("contract_address")]
        public string ContractAddressContractAddress { get; set; }

        [JsonProperty("platform")]
        public Platform Platform { get; set; }
    }

    public partial class Platform
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("coin")]
        public Coin Coin { get; set; }
    }

    public partial class Coin
    {
        [JsonProperty("id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }

    public partial class Status
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [JsonProperty("error_code")]
        public long ErrorCode { get; set; }

        [JsonProperty("error_message")]
        public object ErrorMessage { get; set; }

        [JsonProperty("elapsed")]
        public long Elapsed { get; set; }

        [JsonProperty("credit_count")]
        public long CreditCount { get; set; }

        [JsonProperty("notice")]
        public object Notice { get; set; }
    }

    public enum TagGroup { Algorithm, Category, Industry, Others, Platform };

    public partial class CryptoLogo
    {
        public static CryptoLogo FromJson(string json) => JsonConvert.DeserializeObject<CryptoLogo>(json, Whollet.Model.APIModels.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CryptoLogo self) => JsonConvert.SerializeObject(self, Whollet.Model.APIModels.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TagGroupConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class TagGroupConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TagGroup) || t == typeof(TagGroup?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "ALGORITHM":
                    return TagGroup.Algorithm;
                case "CATEGORY":
                    return TagGroup.Category;
                case "INDUSTRY":
                    return TagGroup.Industry;
                case "OTHERS":
                    return TagGroup.Others;
                case "PLATFORM":
                    return TagGroup.Platform;
            }
            throw new Exception("Cannot unmarshal type TagGroup");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TagGroup)untypedValue;
            switch (value)
            {
                case TagGroup.Algorithm:
                    serializer.Serialize(writer, "ALGORITHM");
                    return;
                case TagGroup.Category:
                    serializer.Serialize(writer, "CATEGORY");
                    return;
                case TagGroup.Industry:
                    serializer.Serialize(writer, "INDUSTRY");
                    return;
                case TagGroup.Others:
                    serializer.Serialize(writer, "OTHERS");
                    return;
                case TagGroup.Platform:
                    serializer.Serialize(writer, "PLATFORM");
                    return;
            }
            throw new Exception("Cannot marshal type TagGroup");
        }

        public static readonly TagGroupConverter Singleton = new TagGroupConverter();
    }
}