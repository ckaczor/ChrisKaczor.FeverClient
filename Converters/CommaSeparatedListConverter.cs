using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChrisKaczor.FeverClient.Converters;

internal class CommaSeparatedListConverter : JsonConverter<IEnumerable<int>>
{
    public override IEnumerable<int> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException("Expected a string");
        }

        var commaSeparatedList = reader.GetString() ?? string.Empty;

        return commaSeparatedList.Split(",").Select(int.Parse).AsEnumerable();
    }

    public override void Write(Utf8JsonWriter writer, IEnumerable<int> value, JsonSerializerOptions options)
    {
        var commaSeparatedList = string.Join(",", value);
        writer.WriteStringValue(commaSeparatedList);
    }
}