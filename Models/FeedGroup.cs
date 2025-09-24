using System.Text.Json.Serialization;
using JetBrains.Annotations;

namespace ChrisKaczor.FeverClient.Models;

[PublicAPI]
public class FeedGroup
{
    [JsonPropertyName("group_id")]
    public required int GroupId { get; set; }

    [JsonPropertyName("feed_ids")]
    public required IEnumerable<int> FeedIds { get; set; }
}