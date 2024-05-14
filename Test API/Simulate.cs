using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Test_API;

public static class Simulate
{
    public static async Task SearchFor(this IPage page, Place place)
    {
        await page.GetByLabel("Search Google Maps").FillAsync(place.Name);
        await page.GetByRole(AriaRole.Gridcell, new PageGetByRoleOptions { NameString = place.Search }).ClickAsync();
    }

    public static async Task NavigateTo(this IPage page, Geolocation where)
    {
        await page.GotoAsync(
            $"https://www.google.com/maps/@{where.Latitude.ToString().Replace(',', '.')}," +
            $"{where.Longitude.ToString().Replace(',', '.')},14.5z?entry=ttu");
    }
}