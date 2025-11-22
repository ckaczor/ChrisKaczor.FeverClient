using ChrisKaczor.FeverClient.Converters;
using ChrisKaczor.FeverClient.Models;
using ChrisKaczor.FeverClient.Responses;
using RestSharp;
using System.Text.Json;

namespace ChrisKaczor.FeverClient;

public class FeverClient
{
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly RestClient _restClient;

    public FeverClient(string url, string apiKey)
    {
        _jsonSerializerOptions = new JsonSerializerOptions();
        _jsonSerializerOptions.Converters.Add(new EpochConverter());
        _jsonSerializerOptions.Converters.Add(new BoolConverter());
        _jsonSerializerOptions.Converters.Add(new CommaSeparatedListConverter());

        _restClient = new RestClient(url);
        _restClient.AddDefaultParameter("api_key", apiKey);
    }

    private async Task<T> PostRestRequest<T>(string api)
    {
        var request = new RestRequest($"/fever/?api&{api}", Method.Post) { AlwaysMultipartFormData = true };

        var response = await _restClient.PostAsync(request);

        if (response == null)
            throw new Exception("Failed to get response from Fever API");

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Error: {response.StatusCode} - {response.Content}");

        if (response.Content == null)
            throw new Exception("Response content is null");

        try
        {
            var responseObject = JsonSerializer.Deserialize<T>(response.Content, _jsonSerializerOptions);

            if (responseObject == null)
                throw new Exception($"Failed to deserialize response content - {response.Content}");

            return responseObject;
        }
        catch (Exception e)
        {
            throw new Exception($"Failed to deserialize response content - {response.Content}", e);
        }
    }

    public async Task<IEnumerable<Group>> GetGroups()
    {
        var groupsResponse = await PostRestRequest<GetGroupsResponse>("groups");

        return groupsResponse.Groups;
    }

    public async Task<IEnumerable<Feed>> GetFeeds()
    {
        var feedsResponse = await PostRestRequest<GetFeedsResponse>("feeds");

        return feedsResponse.Feeds;
    }

    public async Task<IEnumerable<Favicon>> GetFavicons()
    {
        var faviconsResponse = await PostRestRequest<GetFaviconsResponse>("favicons");

        return faviconsResponse.Favicons;
    }

    public async Task<IEnumerable<FeedItem>> GetFeedItems(int sinceId = 1)
    {
        var feedItemsResponse = await PostRestRequest<GetFeedItemsResponse>($"items&since_id={sinceId}");

        return feedItemsResponse.FeedItems;
    }

    public async IAsyncEnumerable<IEnumerable<FeedItem>> GetAllFeedItems()
    {
        var maxId = 1;

        do
        {
            var response = await GetFeedItems(maxId);

            var feedItemList = response.ToArray();

            yield return feedItemList;

            if (feedItemList.Length == 0)
                yield break;

            maxId = feedItemList.Max(fi => fi.Id);
        } while (true);
    }

    public async Task MarkFeedItemAsRead(int feedItemId)
    {
        await PostRestRequest<BaseResponse>($"mark=item&as=read&id={feedItemId}");
    }
}