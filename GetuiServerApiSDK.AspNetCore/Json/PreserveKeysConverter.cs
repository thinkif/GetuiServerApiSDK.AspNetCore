using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GetuiServerApiSDK.AspNetCore.Json;

public class PreserveKeysConverter : JsonConverter<Dictionary<string, Dictionary<string, object>>>
{
    public override void WriteJson(JsonWriter writer, Dictionary<string, Dictionary<string, object>> value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteStartObject();
        foreach (var kvp in value)
        {
            writer.WritePropertyName(kvp.Key); // 保持原始 key
            writer.WriteStartObject();

            if (kvp.Value != null)
            {
                foreach (var innerKvp in kvp.Value)
                {
                    writer.WritePropertyName(innerKvp.Key); // 保持内部 key 原样
                    serializer.Serialize(writer, innerKvp.Value);
                }
            }

            writer.WriteEndObject();
        }
        writer.WriteEndObject();
    }

    public override Dictionary<string, Dictionary<string, object>> ReadJson(JsonReader reader, Type objectType, Dictionary<string, Dictionary<string, object>> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        return serializer.Deserialize<Dictionary<string, Dictionary<string, object>>>(reader);
    }
}