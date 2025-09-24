using System.Text.Json.Serialization;
using ChrisKaczor.FeverClient.Models;

namespace ChrisKaczor.FeverClient.Responses;

internal class GetFeedsResponse : BaseResponse
{
    [JsonPropertyName("feeds")]
    public required IEnumerable<Feed> Feeds { get; set; }

    [JsonPropertyName("feeds_groups")]
    public required IEnumerable<FeedGroup> FeedGroups { get; set; }
}