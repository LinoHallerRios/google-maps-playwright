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
    
    public static async Task<IPage> GetWalkingDirectionsFrom(this IPage page, Place from)
    {
        await SearchFor(page, from);
        await page.GetByRole(AriaRole.Button, new () { NameRegex = new Regex("Directions to " + from.Name) }).ClickAsync();
        await page.GetByRole(AriaRole.Radio, new () { NameString = "Walking" }).ClickAsync();
        return page;
    }
    
    public static async Task To(this IPage page, Place to)
    {
        await Task.Delay(5000);
        await page.GetByPlaceholder("Choose starting point, or click on the map...").FillAsync(to.Name);
        await page.GetByRole(AriaRole.Gridcell, new PageGetByRoleOptions { NameString = to.Search }).ClickAsync();
    }

    public static ILocator AcceptCookiesButton(this IPage page)
        => page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { NameString = "Accept All" });
    
    public static async Task AcceptCookies(this IPage page)
        => await page.AcceptCookiesButton().ClickAsync();
}