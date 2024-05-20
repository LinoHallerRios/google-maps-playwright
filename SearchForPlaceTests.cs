using GoogleMapsPlaywright.Tests.API;
using static GoogleMapsPlaywright.Tests.API.Data; 
using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Tests;

public class SearchForPlaceTests : TestFixture
{
    public static IEnumerable<TestCaseData> TestPlaces()
    {
        yield return new TestCaseData(Berlin, Alexanderplatz);
        yield return new TestCaseData(Berlin, BrandenburgGate);
        yield return new TestCaseData(Berlin, EastSideGallery);
        yield return new TestCaseData(Malaga, LariosStreet);
        yield return new TestCaseData(Bucarest, BatisteiStreet);
    }
    
    [Test]
    [TestCaseSource(nameof(TestPlaces))]
    public async Task SearchForPlaceHasTitleAndDescriptionOnSidebar(Geolocation city, Place place)
    {
        var map = await LoadGoogleMapsPageFrom(city);

        await map.SearchFor(place);

        await Expect(map.WithSidebarTitleFrom(place)).ToBeVisibleAsync();
        await Expect(map.WithSidebarDescriptionFrom(place)).ToBeVisibleAsync();
        
        await map.CloseAsync();
    }
    
}