using System.Text.Json.Serialization;

namespace ChrisKaczor.FeverClient.Responses;

internal class BaseResponse
{
    [JsonPropertyName("api_version")]
    public int ApiVersion { get; set; }

    [JsonPropertyName("auth")]
    public bool Auth { get; set; }

    [JsonPropertyName("last_refreshed_on_time")]
    public DateTimeOffset LastRefreshedOnTime { get; set; }
}