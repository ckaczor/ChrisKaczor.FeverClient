using System.Text.Json.Serialization;
using ChrisKaczor.FeverClient.Models;

namespace ChrisKaczor.FeverClient.Responses;

internal class GetFeedItemsResponse : BaseResponse
{
    [JsonPropertyName("items")]
    public required IEnumerable<FeedItem> FeedItems { get; set; }

    [JsonPropertyName("total_items")]
    public required int TotalItems { get; set; }
}