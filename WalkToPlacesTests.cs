using GoogleMapsPlaywright.Tests.API;
using static GoogleMapsPlaywright.Tests.API.Data;

namespace GoogleMapsPlaywright.Tests;

public class WalkToPlacesTests : TestFixture
{
    public static IEnumerable<TestCaseData> TestDirections()
    {
        yield return new TestCaseData(Alexanderplatz, BrandenburgGate, "Walking 34 min 2.5 km");
        yield return new TestCaseData(EastSideGallery, TvTower, "Walking 35 min 2.5 km");
    }
    
    [Test]
    [TestCaseSource(nameof(TestDirections))]
    public async Task WalkFromOnePlaceToAnother(Place startingLocation, Place destination, String expectedDistance)
    {
        var map = await LoadGoogleMapsPageIn(Berlin);

        await (await map.GetWalkingDirectionsFrom(startingLocation)).To(destination);
        
        await Expect(map.ToHaveTravelDistance(expectedDistance)).ToBeVisibleAsync();
        
        await map.CloseAsync();
    }
}