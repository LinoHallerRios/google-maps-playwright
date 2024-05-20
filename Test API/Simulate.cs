using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Tests.API;

public static class Simulate
{
    public static async Task SearchFor(this IPage page, Place place)
    {
        await page.FillSearchBarWith(place);
        await page.ClickSearchResult(place);
    }

    private static async Task ClickSearchResult(this IPage page, Place place)
    {
        await page.SearchResultThatContains(place).ClickAsync();
    }

    private static async Task FillSearchBarWith(this IPage page, Place place)
    {
        await page.SearchBar().FillAsync(place.Name);
    }
    
    public static async Task<IPage> GetWalkingDirectionsFrom(this IPage page, Place place)
    {
        await page.SearchFor(place);
        await page.ActivateDirectionsFrom(place);
        await page.SelectWalking();
        
        return page;
    }

    private static async Task SelectWalking(this IPage page)
    {
        await page.Walk().ClickAsync();
    }

    private static async Task ActivateDirectionsFrom(this IPage page, Place place)
    {
        await page.DirectionsButtonFrom(place).ClickAsync();
    }

    public static async Task To(this IPage page, Place to)
    {
        await page.FillDestinationFrom(to);
        await page.ClickSearchResult(to);
    }

    private static async Task FillDestinationFrom(this IPage page, Place place)
    {
        await page.DestionationInput().FillAsync(place.Name);
    }

    public static async Task AcceptCookies(this IPage page)
        => await page.AcceptCookiesButton().ClickAsync();
    
    public static async Task NavigateTo(this IPage page, Geolocation where)
    {
        await page.GotoAsync(
            $"https://www.google.com/maps/@{where.Latitude.ToString().Replace(',', '.')}," +
            $"{where.Longitude.ToString().Replace(',', '.')},14.5z?entry=ttu");
    }
}