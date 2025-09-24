using System.Text.Json.Serialization;
using ChrisKaczor.FeverClient.Models;

namespace ChrisKaczor.FeverClient.Responses;

internal class GetFaviconsResponse : BaseResponse
{
    [JsonPropertyName("favicons")]
    public required IEnumerable<Favicon> Favicons { get; set; }
}