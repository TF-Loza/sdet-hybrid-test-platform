using Microsoft.Playwright;

public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    public async Task GoTo()
    {
        await _page.GotoAsync("https://example.com");
    }

    public async Task<string> GetTitle()
    {
        return await _page.TitleAsync();
    }
}