using Xunit;

public class HomeTests : BaseTest
{
    [Fact]
    [Trait("Type", "UI")]
    [Trait("Suite", "Smoke")]

    public async Task Can_Open_Home_Page()
    {
        try
        {
            var homePage = new HomePage(Page);

            await homePage.GoTo();
            var title = await homePage.GetTitle();

            Assert.Contains("Example", title);
        }
        catch
        {
            await TakeScreenshotOnFailure(nameof(Can_Open_Home_Page));
            throw;
        }
    }
}