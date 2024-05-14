using Microsoft.Playwright;

namespace GoogleMapsPlaywright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PlaywrightTest
{
    [Test]
    public async Task SearchForLocationInSearchBar()
    {
        var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });
        
        var context = await browser.NewContextAsync(
            new BrowserNewContextOptions()
            {
                ViewportSize = new ViewportSize() { Width = 1280, Height = 720 },
                Locale = "en-UK",
                TimezoneId = "Europe/Berlin",
                Permissions = new[] { "geolocation" },
                Geolocation = new Geolocation()
                {
                    Latitude = 52.5191918f,
                    Longitude = 13.4166975f,
                },
                IgnoreHTTPSErrors = true
            });
        
        var page = await context.NewPageAsync();
        
        await page.GotoAsync("https://www.google.com/maps/@52.5191918,13.4166975,14.5z?entry=ttu");

        await page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { NameString = "Accept All" }).ClickAsync();

        await page.GetByLabel("Search Google Maps").FillAsync("Alexanderplatz");
        await page.GetByRole(AriaRole.Gridcell, new PageGetByRoleOptions { NameString = "Alexanderplatz Berlin, Germany" }).ClickAsync();

        await Expect(page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = "Alexanderplatz" }))
            .ToBeVisibleAsync();

        await Expect(page.GetByRole(AriaRole.Button,
            new()
            {
                NameString =
                    "Historic meeting and market place rebuilt post-war with modern buildings and 365-meter TV tower."
            })).ToBeVisibleAsync();
    }
}