using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChrisKaczor.FeverClient.Converters;

public class BoolConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.Number)
        {
            throw new JsonException("Expected a numeric boolean value");
        }

        var number = reader.GetInt64();
        return number == 1;
    }

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        var number = value ? 1 : 0;
        writer.WriteNumberValue(number);
    }
}