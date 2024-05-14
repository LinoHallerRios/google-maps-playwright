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
        yield return new TestCaseData(Berlin, TvTower);
        yield return new TestCaseData(Berlin, EastSideGallery);
    }
    
    [Test]
    [TestCaseSource(nameof(TestPlaces))]
    public async Task SearchForPlaceAndHaveTitleOnSidebar(Geolocation city, Place place)
    {
        var map = await LoadGoogleMapsPage();
        
        await map.NavigateTo(city);

        await map.SearchFor(place);

        await Expect(map.WithSidebarTitleFrom(place)).ToBeVisibleAsync();
        await Expect(await map.WithSidebarDescriptionFrom(place)).ToBeVisibleAsync();
    }
}