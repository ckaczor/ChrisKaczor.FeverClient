using System.Text.Json.Serialization;
using ChrisKaczor.FeverClient.Models;

namespace ChrisKaczor.FeverClient.Responses;

internal class GetGroupsResponse : BaseResponse
{
    [JsonPropertyName("groups")]
    public required IEnumerable<Group> Groups { get; set; }

    [JsonPropertyName("feeds_groups")]
    public required IEnumerable<FeedGroup> FeedGroups { get; set; }
}