using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Test_API;

public static class Locations
{
    public static Geolocation Berlin => new()
    {
        Latitude = 52.5191918f,
        Longitude = 13.4166975f,
    };

    public static Place Alexanderplatz = new()
    {
        Name = "Alexanderplatz",
        Description = "Historic meeting and market place rebuilt post-war with modern buildings and 365-meter TV tower.",
        Search = "Alexanderplatz Berlin, Germany"
    };
}

public struct Place
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Search { get; set; }
}