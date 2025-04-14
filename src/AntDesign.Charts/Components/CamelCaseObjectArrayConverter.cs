using System;
using System.Text.Json;
using System.Text.Json.Serialization;

internal class CamelCaseObjectArrayConverter : JsonConverter<object[]>
{
    public override object[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using (var doc = JsonDocument.ParseValue(ref reader))
        {
            // Deserialize the JSON array into an object array
            if (doc.RootElement.ValueKind == JsonValueKind.Array)
            {
                var array = new object[doc.RootElement.GetArrayLength()];
                int index = 0;
                foreach (var element in doc.RootElement.EnumerateArray())
                {
                    array[index++] = JsonSerializer.Deserialize<object>(element.GetRawText(), options);
                }
                return array;
            }

            throw new JsonException("Expected a JSON array.");
        }
    }

    public override void Write(Utf8JsonWriter writer, object[] value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        foreach (var item in value)
        {
            // Serialize each item in the array with camelCase naming policy
            var json = JsonSerializer.Serialize(item, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            writer.WriteRawValue(json);
        }

        writer.WriteEndArray();
    }
}
