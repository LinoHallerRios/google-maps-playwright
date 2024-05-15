using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Data;

namespace GoogleMapsPlaywright.Test_API;

[Parallelizable(ParallelScope.Fixtures)]
public class TestFixture : BrowserTest
{
    string GoogleMaps => "https://www.google.com/maps/";
    
    protected async Task<IPage> LoadGoogleMapsPageIn(Geolocation from)
    {
        var context = await Browser.NewContextAsync(new BrowserNewContextOptions()
        {
            Locale = "en-UK",
            TimezoneId = "Europe/Berlin",
            Geolocation = from,
            IgnoreHTTPSErrors = true
        });
        
        var Map = await context.NewPageAsync();

        await Map.GotoAsync(GoogleMaps);

        if (await Map.AcceptCookiesButton().IsVisibleAsync())
            await Map.AcceptCookies();

        await Expect(Map).ToHaveTitleAsync(new Regex("Google Maps"));
        
        await Map.NavigateTo(from);

        return Map;
    }
}