using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChrisKaczor.FeverClient.Converters;

public class EpochConverter : JsonConverter<DateTimeOffset>
{
    public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException("Expected a numeric epoch timestamp");
        }

        var unixTimestamp = reader.GetInt64();
        return DateTimeOffset.FromUnixTimeSeconds(unixTimestamp);
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
    {
        var unixTimestamp = value.ToUnixTimeSeconds();
        writer.WriteNumberValue(unixTimestamp);
    }
}