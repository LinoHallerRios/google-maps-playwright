using GoogleMapsPlaywright.Test_API;
using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Data;

namespace GoogleMapsPlaywright;

public class WalkFromOnePlaceToAnotherTests : TestFixture
{
    [Test]
    public async Task WalkFromOnePlaceToAnother()
    {
        var map = await LoadGoogleMapsPageIn(Berlin);

        await (await map.GetWalkingDirectionsFrom(Alexanderplatz)).To(BrandenburgGate);
        
        await Expect(map.GetByRole(AriaRole.Link, new() { NameRegex = new Regex("Walking 34 min 2.5 km") }))
            .ToBeVisibleAsync();
        
        await map.CloseAsync();
    }
}