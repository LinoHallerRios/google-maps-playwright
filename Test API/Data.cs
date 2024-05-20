using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Tests.API;

public static class Data
{
    public static Geolocation Berlin => new()
    {
        Latitude = 52.5191918f,
        Longitude = 13.4166975f,
    };

    public static Geolocation Bucarest => new()
    {
        Latitude = 44.4242239f,
        Longitude = 26.1025165f,
    };

    public static Place Alexanderplatz = new()
    {
        Name = "Alexanderplatz",
        Description = "Historic meeting and market place rebuilt post-war with modern buildings and 365-meter TV tower.",
        SearchResult = "Alexanderplatz Berlin, Germany"
    };
    
    public static Place TvTower = new()
    {
        Name = "Berliner Fernsehturm",
        Description = "368m-tall tower, opened in 1969, with a viewing gallery at 203m and revolving restaurant at 207m.",
        SearchResult = "Berliner Fernsehturm 1 Panoramastraße, Berlin, Germany"
    };
    
    public static Place BrandenburgGate = new()
    {
        Name = "Brandenburg Gate",
        Description = "Restored 18th-century gate & landmark with 12 Doric columns topped by a classical goddess statue.",
        SearchResult = "Brandenburg Gate Pariser Platz, Berlin, Germany"
    };
    
    public static Place EastSideGallery = new()
    {
        Name = "East Side Gallery",
        Description = "Conserved graffiti project by 118 artists covering part of the Berlin Wall & celebrating its demise.",
        SearchResult = "East Side Gallery Mühlenstraße, Berlin, Germany"
    };

    public static Place BatisteiStreet = new ()
    {
        Name = "Str. Batiștei 12",
        Description = "Address, Str. Batiștei 12, București 030167, Romania",
        SearchResult = "Str. Batiștei12 Bucharest, Romania"
    };
}

public struct Place
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string SearchResult { get; set; }
}