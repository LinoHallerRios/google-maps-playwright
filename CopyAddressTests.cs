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
        
        Assert.That(Markveien53Street.Address, Is.EqualTo(await map.CopiedAddress()));
    }
}