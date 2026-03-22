using System.Text.Json;
using ApiTests.Clients;
using ApiTests.Constants;
using ApiTests.Models;

namespace ApiTests.Tests;

public class PostsApiTests
{
    private readonly JsonPlaceholderClient _client;
    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public PostsApiTests()
    {
        _client = new JsonPlaceholderClient();
    }

    [Fact]
    [Trait("Type", "API")]
    [Trait("Suite", "Smoke")]
    public async Task GetPosts_WhenEndpointIsAvailable_ShouldReturn200Ok()
    {
        var response = await _client.GetAsync(ApiEndpoints.Posts);

        Assert.Equal(200, (int)response.StatusCode);
        Assert.False(string.IsNullOrWhiteSpace(response.Content));
    }

    [Fact]
    [Trait("Type", "API")]
    [Trait("Suite", "Smoke")]
    public async Task GetSinglePost_WithValidId_ShouldReturnCorrectPost()
    {
        var response = await _client.GetAsync(ApiEndpoints.PostById(1));

        Assert.Equal(200, (int)response.StatusCode);
        Assert.NotNull(response.Content);

        var post = JsonSerializer.Deserialize<Post>(response.Content!, _jsonOptions);
        Assert.NotNull(post);
        Assert.Equal(1, post!.Id);
        Assert.Equal(1, post.UserId);
        Assert.False(string.IsNullOrWhiteSpace(post.Title));
    }

    [Fact]
    [Trait("Type", "API")]
    [Trait("Suite", "Smoke")]
    public async Task FilterPosts_ByUserId_ShouldReturnOnlyMatchingPosts()
    {
        var response = await _client.GetAsync(ApiEndpoints.PostsByUserId(1));

        Assert.Equal(200, (int)response.StatusCode);
        Assert.NotNull(response.Content);

        var posts = JsonSerializer.Deserialize<List<Post>>(response.Content!, _jsonOptions);
        Assert.NotNull(posts);
        Assert.NotEmpty(posts!);
        Assert.All(posts!, post => Assert.Equal(1, post.UserId));
    }

    [Fact]
[Trait("Type", "API")]
[Trait("Suite", "Smoke")]
public async Task CreatePost_WithValidData_ShouldReturn201AndCreatedPost()
{
    // Arrange
    var newPost = new CreatePostRequest
    {
        UserId = 1,
        Title = "Test Title",
        Body = "Test Body"
    };

    // Act
    var response = await _client.PostAsync(ApiEndpoints.Posts, newPost);

    // Assert status code
    Assert.Equal(201, (int)response.StatusCode);
    Assert.NotNull(response.Content);

    // Deserialize response
    var createdPost = JsonSerializer.Deserialize<Post>(response.Content!, _jsonOptions);

    Assert.NotNull(createdPost);
    Assert.Equal(newPost.UserId, createdPost!.UserId);
    Assert.Equal(newPost.Title, createdPost.Title);
    Assert.Equal(newPost.Body, createdPost.Body);
}

[Fact]
[Trait("Type", "API")]
[Trait("Suite", "Smoke")]
public async Task DeletePost_WithValidId_ShouldReturn200Or204()
{
    // Act
    var response = await _client.DeleteAsync(ApiEndpoints.PostById(1));

    // Assert
    Assert.True(
        (int)response.StatusCode == 200 || (int)response.StatusCode == 204,
        $"Expected status code 200 or 204, but got {(int)response.StatusCode}");
}

[Fact]
[Trait("Type", "API")]
[Trait("Suite", "Regression")]
public async Task GetSinglePost_WithNonExistentId_ShouldReturn404OrEmptyObject()
{
    // Act
    var response = await _client.GetAsync(ApiEndpoints.PostById(999999));

    // Assert
    Assert.True(
        (int)response.StatusCode == 404 || (response.Content != null && response.Content.Trim() == "{}"),
        $"Expected status code 404 or empty object response, but got {(int)response.StatusCode} with body: {response.Content}");
}

[Fact]
[Trait("Type", "API")]
[Trait("Suite", "Regression")]
public async Task FilterPosts_ByNonExistentUserId_ShouldReturnEmptyList()
{
    // Act
    var response = await _client.GetAsync(ApiEndpoints.PostsByUserId(999999));

    // Assert
    Assert.Equal(200, (int)response.StatusCode);
    Assert.NotNull(response.Content);

    var posts = JsonSerializer.Deserialize<List<Post>>(response.Content!, _jsonOptions);

    Assert.NotNull(posts);
    Assert.Empty(posts!);
}

}