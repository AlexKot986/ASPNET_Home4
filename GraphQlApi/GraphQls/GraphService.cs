namespace GraphQlApi.GraphQls;

public class GraphService : IGraphService
{
    protected readonly HttpClient _client;

    public GraphService(HttpClient client)
    {
        _client = client;
    }


    public async Task<T?> Get<T>(string url)
    {
        var result = await _client.GetFromJsonAsync<T>(url);
        return result;
    }

    public async Task<string> Post<T>(string url, T request)
    {
        var result = await _client.PostAsJsonAsync(url, request);
        return await Response(result);
    }

    private static async Task<string> Response(HttpResponseMessage result)
    {
        var body = await result.Content.ReadAsStringAsync();
        return $"Status: {(int)result.StatusCode} ({result.ReasonPhrase}); Body: {body}";
    }
}
