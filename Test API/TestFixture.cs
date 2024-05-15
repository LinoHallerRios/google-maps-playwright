﻿using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Locations;

namespace GoogleMapsPlaywright.Test_API;

[Parallelizable(ParallelScope.Children)]
public class TestFixture : BrowserTest
{
    string GoogleMaps => "https://www.google.com/maps/";
    
    protected async Task<IPage> LoadGoogleMapsPage()
    {
        var Map = await Browser.NewPageAsync(new BrowserNewPageOptions()
        {
            ViewportSize = new ViewportSize() { Width = 1280, Height = 720 },
            Locale = "en-UK",
            TimezoneId = "Europe/Berlin",
            Permissions = new[] { "geolocation" },
            Geolocation = Berlin,
            IgnoreHTTPSErrors = true
        });

        await Map.GotoAsync(GoogleMaps);

        if (await Map.AcceptCookiesButton().IsVisibleAsync())
            await Map.AcceptCookies();

        await Expect(Map).ToHaveTitleAsync(new Regex("Google Maps"));

        return Map;
    }
}