using Microsoft.Playwright;
using static GoogleMapsPlaywright.Tests.API.Simulate;
using static GoogleMapsPlaywright.Tests.API.Find;

namespace GoogleMapsPlaywright.Tests;

[Parallelizable(ParallelScope.Fixtures)]
public class TestFixture : BrowserTest
{
    string GoogleMapsURL => "https://www.google.com/maps/";
    string GoogleMapsWebTitle => "Google Maps";
    
    protected async Task<IPage> LoadGoogleMapsPageFrom(Geolocation place)
    {
        var context = await Browser.NewContextAsync(
        new BrowserNewContextOptions()
        {
            Locale = "en-UK",
            TimezoneId = "Europe/Berlin",
            Geolocation = place,
            IgnoreHTTPSErrors = true
        });

        var map = await context.NewPageAsync();

        await map.GotoAsync(GoogleMapsURL);

        if (await NeedsToAcceptCookies(map))
            await map.AcceptCookies();

        await Expect(map).ToHaveTitleAsync(new Regex(GoogleMapsWebTitle));

        await map.NavigateTo(place);

        return map;
    }

    private static async Task<bool> NeedsToAcceptCookies(IPage map)
        => await map.AcceptCookiesButton().IsVisibleAsync();
}