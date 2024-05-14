using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Locations;

namespace GoogleMapsPlaywright.Test_API;

[Parallelizable(ParallelScope.Children)]
public class TestFixture : PlaywrightTest
{
    string GoogleMaps => "https://www.google.com/maps/";

    protected IPage Map;

    IBrowserContext context;
    IBrowser browser;

    [SetUp]
    public async Task Setup()
    {
        browser = await LaunchChromium();

        await LoadGoogleMapsPageFrom(Berlin);
    }

    [TearDown]
    public async Task Close()
    {
        await context.CloseAsync();
    }

    async Task<IBrowser> LaunchChromium()
    {
        return await Playwright.Chromium.LaunchAsync(new()
        {
            Headless = false,
            Timeout = 3000,
        });
    }

    async Task LoadGoogleMapsPageFrom(Geolocation where)
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

        Map = await context.NewPageAsync();

        await Map.GotoAsync(GoogleMaps);

        if (await Map.AcceptCookiesButton().IsVisibleAsync())
            await Map.AcceptCookies();

        await Expect(Map).ToHaveTitleAsync(new Regex("Google Maps"));
    }
}