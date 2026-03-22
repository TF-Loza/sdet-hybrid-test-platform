namespace ApiTests.Constants;

public static class ApiEndpoints
{
    public const string Posts = "/posts";

    public static string PostById(int id) => $"/posts/{id}";

    public static string PostsByUserId(int userId) => $"/posts?userId={userId}";
}