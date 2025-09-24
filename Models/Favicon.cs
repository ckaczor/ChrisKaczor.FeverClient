using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace ChrisKaczor.FeverClient.Models;

[PublicAPI]
public class Favicon
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("data")]
    public required string Data { get; set; }
}