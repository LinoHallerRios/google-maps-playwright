using FluentAssertions;
using GoogleMapsPlaywright.Test_API;
using Microsoft.Playwright;
using static GoogleMapsPlaywright.Test_API.Locations;

namespace GoogleMapsPlaywright;

public class SearchForAddress : TestFixture
{
    [Test]
    public async Task SearchForCopiedClipboardAddressTest()
    {
        var map = await LoadGoogleMapsPage(Oslo);

        await map.SearchFor(Markveien53Street);
        
        (await map.CopyAddress()).Should().Be(Markveien53Street.Address);
    }
}