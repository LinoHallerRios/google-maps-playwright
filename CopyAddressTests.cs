using FluentAssertions;
using GoogleMapsPlaywright.Test_API;
using static GoogleMapsPlaywright.Test_API.Locations;

namespace GoogleMapsPlaywright;

public class CopyAddressTests : TestFixture
{
    [Test]
    public async Task SearchForPlaceAndCopyAddressToClipboard()
    {
        var map = await LoadGoogleMapsPageIn(Oslo);

        await map.SearchFor(Markveien53Street);
        
        (await map.CopiedAddress()).Should().Be(Markveien53Street.Address);
    }
}