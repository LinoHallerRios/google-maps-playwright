using GoogleMapsPlaywright.Test_API;
using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Data;

namespace GoogleMapsPlaywright;

public class SearchForPlaceTests : TestFixture
{
    public static IEnumerable<TestCaseData> TestPlaces()
    {
        yield return new TestCaseData(Berlin, Alexanderplatz);
        yield return new TestCaseData(Berlin, BrandenburgGate);
        yield return new TestCaseData(Berlin, TvTower);
        yield return new TestCaseData(Berlin, EastSideGallery);
    }
    
 

    public async Task SearchForPlaceHasTitleAndDescriptionOnSidebar(Geolocation city, Place place)
    {
        var map = await LoadGoogleMapsPageIn(city);

        await map.SearchFor(place);

        await Expect(map.WithSidebarTitleFrom(place)).ToBeVisibleAsync();
        await Expect(map.WithSidebarDescriptionFrom(place)).ToBeVisibleAsync();
        
        await map.CloseAsync();
    }
}