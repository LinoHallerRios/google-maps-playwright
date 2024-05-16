using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Test_API;

public static class Find
{
    public static ILocator WithSidebarDescriptionFrom(this IPage page, Place place)
        => page.GetByRole(AriaRole.Button, new() { NameRegex = new Regex(place.Description) });

    public static ILocator WithSidebarTitleFrom(this IPage page, Place place)
        => page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = place.Name });

    public static ILocator SearchBar(this IPage page) 
        => page.GetByLabel("Search Google Maps");

    public static ILocator ToHaveTravelDistance(this IPage page, string expectedDistance)
        => page.GetByRole(AriaRole.Link, new() { NameRegex = new Regex(expectedDistance) });

    public static ILocator AcceptCookiesButton(this IPage page)
        => page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { NameString = "Accept All" });

    public static ILocator DestionationInput(this IPage page)
        => page.GetByPlaceholder("Choose starting point, or click on the map...");

    public static ILocator DirectionsButtonFrom(this IPage page, Place place)
        => page.GetByRole(AriaRole.Button, new() { NameRegex = new Regex("Directions to " + place.Name) });
    
    public static ILocator Walk(this IPage page) 
        => page.GetByRole(AriaRole.Radio, new () { NameString = "Walking" });
    
    public static ILocator SearchResultThatContains(this IPage page, Place place) 
        => page.GetByRole(AriaRole.Gridcell, new PageGetByRoleOptions { NameString = place.Search });
}