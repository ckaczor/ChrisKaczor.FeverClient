using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace ChrisKaczor.FeverClient.Models;

[PublicAPI]
public class FeedItem
{
    [JsonPropertyName("id")]
    public required int Id { get; set; }

    [JsonPropertyName("feed_id")]
    public required int FeedId { get; set; }

    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [JsonPropertyName("author")]
    public required string Author { get; set; }

    [JsonPropertyName("html")]
    public required string Html { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("is_saved")]
    public required bool IsSaved { get; set; }

    [JsonPropertyName("is_read")]
    public required bool IsRead { get; set; }

    [JsonPropertyName("created_on_time")]
    public required DateTimeOffset CreatedOnTime { get; set; }
}