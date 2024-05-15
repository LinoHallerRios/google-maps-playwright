﻿using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Locations;

namespace GoogleMapsPlaywright.Test_API;

[Parallelizable(ParallelScope.Children)]
public class TestFixture : BrowserTest
{
    string GoogleMaps => "https://www.google.com/maps/";
    
    protected async Task<IPage> LoadGoogleMapsPage(Geolocation from)
    {
        var context = await Browser.NewContextAsync(new BrowserNewContextOptions()
        {
            Locale = "en-UK",
            TimezoneId = "Europe/Berlin",
            Permissions = new[] { "geolocation", "clipboard-read" },
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