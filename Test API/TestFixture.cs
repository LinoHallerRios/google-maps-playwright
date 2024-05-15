using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Locations;

namespace GoogleMapsPlaywright.Test_API;

[Parallelizable(ParallelScope.Self)]
public class TestFixture : PlaywrightTest
{
    string GoogleMaps => "https://www.google.com/maps/";
    
    IBrowserContext context;
    IBrowser browser;

    [SetUp]
    public async Task Setup()
    {
        browser = await LaunchChromium();

        await CreateBrowserFrom(Berlin);
    }

    async Task<IBrowser> LaunchChromium()
    {
        return await Playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            Timeout = 3000,
        });
    }

    async Task CreateBrowserFrom(Geolocation where)
    {
        context = await browser.NewContextAsync(
            new BrowserNewContextOptions()
            {
                ViewportSize = new ViewportSize() { Width = 1280, Height = 720 },
                Locale = "en-UK",
                TimezoneId = "Europe/Berlin",
                Permissions = new[] { "geolocation" },
                Geolocation = where,
                IgnoreHTTPSErrors = true
            });
    }

    protected async Task<IPage> LoadGoogleMapsPage()
    {
        var Map = await context.NewPageAsync();

        await Map.GotoAsync(GoogleMaps);

        if (await Map.AcceptCookiesButton().IsVisibleAsync())
            await Map.AcceptCookies();

        await Expect(Map).ToHaveTitleAsync(new Regex("Google Maps"));

        return Map;
    }
}