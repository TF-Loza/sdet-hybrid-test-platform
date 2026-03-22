using Microsoft.Playwright;

public class LoginPage
{
    private readonly IPage _page;
    private readonly string _baseUrl;

    public LoginPage(IPage page, string baseUrl)
    {
        _page = page;
        _baseUrl = baseUrl;
    }

    public async Task GoTo()
    {
        await _page.GotoAsync(_baseUrl);
    }

    public async Task Login(string username, string password)
    {
        await _page.FillAsync("#user-name", username);
        await _page.FillAsync("#password", password);
        await _page.ClickAsync("#login-button");
    }

    public async Task<string> GetErrorMessage()
    {
        return await _page.InnerTextAsync("[data-test='error']");
    }
}