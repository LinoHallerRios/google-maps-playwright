using GoogleMapsPlaywright.Test_API;
using Microsoft.Playwright;

namespace GoogleMapsPlaywright;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : TestFixture
{
    [Test]
    public async Task SearchForLocationInSearchBar()
    {
        await Map.NavigateTo(Locations.Berlin);

        await Map.SearchFor(Locations.Alexanderplatz);

        await Expect(Map.WithSidebarTitleFrom(Locations.Alexanderplatz)).ToBeVisibleAsync();
        await Expect(await Map.WithSidebarDescriptionFrom(Locations.Alexanderplatz)).ToBeVisibleAsync();
    }
}