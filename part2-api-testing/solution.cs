using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

// ------------------------------------------------------
// Part 2: Basic API Testing - QA Analyst Assessment
// Target API: https://jsonplaceholder.typicode.com/
// Language:   C#  |  Framework: xUnit
// ------------------------------------------------------

public class Solution
{
    private readonly HttpClient _client;

    public Solution()
    {
        _client = new HttpClient
        {
            BaseAddress = new System.Uri("https://jsonplaceholder.typicode.com/")
        };
    }

    // Model for GET /users/{id}
    public record User(int Id, string Name, string Email);

    // Model for POST /posts
    public record Post(int UserId, int Id, string Title, string Body);

    // Test 1: Verify GET /users/1 returns user details correctly
    [Fact(DisplayName = "GET /users/1 - verify valid user response")]
    public async Task GetUser_ShouldReturnUserWithRequiredFields()
    {
        var response = await _client.GetAsync("users/1");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var user = await response.Content.ReadFromJsonAsync<User>();

        // Check important fields
        Assert.NotNull(user);
        Assert.Equal(1, user.Id);
        Assert.False(string.IsNullOrEmpty(user.Name));
        Assert.False(string.IsNullOrEmpty(user.Email));
    }

    // Test 2: Verify POST /posts creates a new post successfully
    [Fact(DisplayName = "POST /posts - verify post creation")]
    public async Task CreatePost_ShouldReturnCreatedPost()
    {
        var newPost = new
        {
            userId = 1,
            title = "Test Post Title",
            body = "This is a sample post created during API testing."
        };

        var response = await _client.PostAsJsonAsync("posts", newPost);
        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var createdPost = await response.Content.ReadFromJsonAsync<Post>();

        // Verify returned post matches what was sent
        Assert.Equal(newPost.title, createdPost.Title);
        Assert.Equal(newPost.body, createdPost.Body);
        Assert.Equal(newPost.userId, createdPost.UserId);
    }

    // Test 3: Verify GET /users/999 returns 404 for non-existing user
    [Fact(DisplayName = "GET /users/999 - verify 404 for missing user")]
    public async Task GetNonExistentUser_ShouldReturn404()
    {
        var response = await _client.GetAsync("users/999");
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
