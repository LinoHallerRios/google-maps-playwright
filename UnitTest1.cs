using Microsoft.Playwright;

namespace GoogleMapsPlaywright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PlaywrightTest
{
    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntropage()
    {
        var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        
        var context = await browser.NewContextAsync();
        
        var page = await context.NewPageAsync();
        
        await page.GotoAsync("https://playwright.dev");

        // Expect a title "to contain" a substring.
        await Expect(page).ToHaveTitleAsync(new Regex("Playwright"));

        // create a locator
        var getStarted = page.Locator("text=Get Started");

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(getStarted).ToHaveAttributeAsync("href", "/docs/intro");

        // Click the get started link.
        await getStarted.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(page).ToHaveURLAsync(new Regex(".*intro"));
    }
}