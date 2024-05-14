using GoogleMapsPlaywright.Test_API;
using Microsoft.Playwright;

namespace GoogleMapsPlaywright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PlaywrightTest
{
    string GoogleMaps => "https://www.google.com/maps/";

    protected IPage Map;

    IBrowserContext context;
    IBrowser browser;

    [SetUp]
    public async Task Setup()
    {
        browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false
        });

        context = await browser.NewContextAsync(
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

        Map = await context.NewPageAsync();

        await Map.GotoAsync(GoogleMaps);

        if (await Map.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { NameString = "Accept All" })
                .IsVisibleAsync())
            await Map.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { NameString = "Accept All" }).ClickAsync();

        await Expect(Map).ToHaveTitleAsync(new Regex("Google Maps"));
    }

    [TearDown]
    public async Task Close()
    {
        await context.CloseAsync();
    }

    [Test]
    public async Task SearchForLocationInSearchBar()
    {
        await Map.NavigateTo(Locations.Berlin);

        await Map.SearchFor(Locations.Alexanderplatz);

        await Expect(Map.WithSidebarTitleFrom(Locations.Alexanderplatz)).ToBeVisibleAsync();
        await Expect(await Map.WithSidebarDescriptionFrom(Locations.Alexanderplatz)).ToBeVisibleAsync();
    }
}