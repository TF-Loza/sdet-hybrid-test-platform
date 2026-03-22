using Xunit;

public class LoginTests : BaseTest
{
    [Fact]
    [Trait("Type", "UI")]
    [Trait("Suite", "Smoke")]
    public async Task Login_With_Valid_Credentials()
    {
        try
        {
            var loginPage = new LoginPage(Page, Settings.BaseUrl);

            await loginPage.GoTo();
            await loginPage.Login("standard_user", "secret_sauce");

            Assert.Contains("inventory", Page.Url);
        }
        catch
        {
            await TakeScreenshotOnFailure(nameof(Login_With_Valid_Credentials));
            throw;
        }
    }

    [Fact]
    [Trait("Type", "UI")]
    [Trait("Suite", "Smoke")]
    public async Task Login_With_Invalid_Credentials()
    {
        try
        {
            var loginPage = new LoginPage(Page, Settings.BaseUrl);

            await loginPage.GoTo();
            await loginPage.Login("wrong_user", "wrong_pass");

            var error = await loginPage.GetErrorMessage();

            Assert.Contains("Username and password do not match", error);
        }
        catch
        {
            await TakeScreenshotOnFailure(nameof(Login_With_Invalid_Credentials));
            throw;
        }
    }

    [Fact]
    [Trait("Type", "UI")]
    [Trait("Suite", "Smoke")]
    public async Task Login_With_Empty_Fields()
    {
        try
        {
            var loginPage = new LoginPage(Page, Settings.BaseUrl);

            await loginPage.GoTo();
            await loginPage.Login("", "");

            var error = await loginPage.GetErrorMessage();

            Assert.Contains("Username is required", error);
        }
        catch
        {
            await TakeScreenshotOnFailure(nameof(Login_With_Empty_Fields));
            throw;
        }
    }
}