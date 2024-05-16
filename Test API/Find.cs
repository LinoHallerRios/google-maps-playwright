using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Test_API;

public static class Find
{
    public static ILocator WithSidebarDescriptionFrom(this IPage page, Place place)
    {
        return page.GetByRole(AriaRole.Button, new() { NameRegex = new Regex(place.Description) });
    }
    
    public static ILocator WithSidebarTitleFrom(this IPage page, Place place)
    {
        return page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = place.Name});
    }

    public static ILocator ToHaveTravelDistance(this IPage page, string expectedDistance)
    {
        return page.GetByRole(AriaRole.Link, new() { NameRegex = new Regex(expectedDistance) });
    }
}