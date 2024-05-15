using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Test_API;

public static class Find
{
    public static ILocator WithSidebarDescriptionFrom(this IPage page, Place place)
    {
        return page.GetByRole(AriaRole.Button, new() { NameString = place.Description });
    }
    
    public static ILocator WithSidebarTitleFrom(this IPage page, Place place)
    {
        return page.GetByRole(AriaRole.Heading, new PageGetByRoleOptions { NameString = place.Name});
    }
}