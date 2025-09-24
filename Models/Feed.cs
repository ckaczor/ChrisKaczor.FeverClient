using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace ChrisKaczor.FeverClient.Models;

[PublicAPI]
public class Feed
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("favicon_id")]
    public required int FaviconId { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("site_url")]
    public required string SiteUrl { get; set; }

    [JsonPropertyName("last_updated_on_time")]
    public required DateTimeOffset LastUpdatedOnTime { get; set; }
}