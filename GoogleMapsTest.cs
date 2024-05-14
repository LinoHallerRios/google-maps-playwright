using GoogleMapsPlaywright.Test_API;
using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Locations;

namespace GoogleMapsPlaywright;

public class Tests : TestFixture
{
    public static IEnumerable<TestCaseData> TestPlaces()
    {
        yield return new TestCaseData(Berlin, Alexanderplatz);
        yield return new TestCaseData(Berlin, BrandenburgGate);
        yield return new TestCaseData(Berlin, Fernsehturm);
    }
    
    [Test]
    [TestCaseSource(nameof(TestPlaces))]
    public async Task SearchForPlaceAndHaveTitleOnSidebar(Geolocation city, Place place)
    {
        await Map.NavigateTo(city);

        await Map.SearchFor(place);

        await Expect(Map.WithSidebarTitleFrom(place)).ToBeVisibleAsync();
        await Expect(await Map.WithSidebarDescriptionFrom(place)).ToBeVisibleAsync();
    }
}