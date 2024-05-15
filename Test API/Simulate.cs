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
    
    public static async Task<string> CopyAddress(this IPage page)
    {
        await page.GetByRole(AriaRole.Button, new () { NameString = "Copy address" }).ClickAsync();
        return await page.EvaluateAsync<string>("navigator.clipboard.readText()");
    }

    public static ILocator AcceptCookiesButton(this IPage page)
        => page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { NameString = "Accept All" });
    
    public static async Task AcceptCookies(this IPage page)
        => await page.AcceptCookiesButton().ClickAsync();
}