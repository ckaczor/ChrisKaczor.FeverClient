using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace ChrisKaczor.FeverClient.Models;

[PublicAPI]
public class Group
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }
}