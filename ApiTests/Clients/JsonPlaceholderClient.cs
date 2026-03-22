using ApiTests.Config;
using RestSharp;

namespace ApiTests.Clients;

public class JsonPlaceholderClient
{
    private readonly RestClient _client;

    public JsonPlaceholderClient()
    {
        _client = new RestClient(ConfigurationHelper.BaseUrl);
    }

    public async Task<RestResponse> GetAsync(string resource)
    {
        var request = new RestRequest(resource, Method.Get);
        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> PostAsync(string resource, object body)
    {
        var request = new RestRequest(resource, Method.Post);
        request.AddJsonBody(body);

        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> PutAsync(string resource, object body)
    {
        var request = new RestRequest(resource, Method.Put);
        request.AddJsonBody(body);

        return await _client.ExecuteAsync(request);
    }

    public async Task<RestResponse> DeleteAsync(string resource)
{
    var request = new RestRequest(resource, Method.Delete);
    return await _client.ExecuteAsync(request);
}
}