using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using Xunit;

public class BaseTest : IAsyncLifetime
{
    protected IPlaywright Playwright = null!;
    protected IBrowser Browser = null!;
    protected IPage Page = null!;
    protected TestSettings Settings = null!;

    public async Task InitializeAsync()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        Settings = configuration
            .GetSection("TestSettings")
            .Get<TestSettings>()!;

        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = Settings.Headless
        });

        Page = await Browser.NewPageAsync();
    }

    protected async Task TakeScreenshotOnFailure(string testName)
    {
        var screenshotsDir = Path.Combine(AppContext.BaseDirectory, "Screenshots");
        Directory.CreateDirectory(screenshotsDir);

        var safeFileName = string.Concat(testName.Split(Path.GetInvalidFileNameChars()));
        var filePath = Path.Combine(screenshotsDir, $"{safeFileName}.png");

        await Page.ScreenshotAsync(new PageScreenshotOptions
        {
            Path = filePath,
            FullPage = true
        });
    }

    public async Task DisposeAsync()
    {
        await Page.CloseAsync();
        await Browser.CloseAsync();
        Playwright.Dispose();
    }
}