using GoogleMapsPlaywright.Test_API;
using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Data;

namespace GoogleMapsPlaywright;

public class WalkFromOnePlaceToAnotherTests : TestFixture
{
    [Test]
    public async Task SearchForPlaceAndCopyAddressToClipboard()
    {
        var map = await LoadGoogleMapsPageIn(Berlin);

        await map.SearchFor(Alexanderplatz);
        
        await map.GetByRole(AriaRole.Button, new () { NameRegex = new Regex("Directions to") }).ClickAsync();
        
        await map.GetByRole(AriaRole.Radio, new () { NameString = "Walking" }).ClickAsync();
        
        await map.GetByPlaceholder("Choose starting point, or click on the map...").FillAsync(BrandenburgGate.Name);
        
        await map.GetByRole(AriaRole.Gridcell, new PageGetByRoleOptions { NameString = BrandenburgGate.Search }).ClickAsync();
        
        await Expect(map.GetByRole(AriaRole.Link, new() { NameRegex = new Regex("Walking 34 min 2.5 km") }))
            .ToBeVisibleAsync();
    }
}