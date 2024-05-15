﻿using Microsoft.Playwright;

namespace GoogleMapsPlaywright.Test_API;

public static class Locations
{
    public static Geolocation Berlin => new()
    {
        Latitude = 52.5191918f,
        Longitude = 13.4166975f,
    };
    
    public static Geolocation Oslo => new()
    {
        Latitude = 59.9141575f,
        Longitude = 10.7601671f,
    };

    public static Place Alexanderplatz = new()
    {
        Name = "Alexanderplatz",
        Description = "Historic meeting and market place rebuilt post-war with modern buildings and 365-meter TV tower.",
        Search = "Alexanderplatz Berlin, Germany"
    };
    
    public static Place TvTower = new()
    {
        Name = "Berliner Fernsehturm",
        Description = "368m-tall tower, opened in 1969, with a viewing gallery at 203m and revolving restaurant at 207m.",
        Search = "Berliner Fernsehturm 1 Panoramastraße, Berlin, Germany"
    };
    
    public static Place BrandenburgGate = new()
    {
        Name = "Brandenburg Gate",
        Description = "Restored 18th-century gate & landmark with 12 Doric columns topped by a classical goddess statue.",
        Search = "Brandenburg Gate Pariser Platz, Berlin, Germany"
    };
    
    public static Place EastSideGallery = new()
    {
        Name = "East Side Gallery",
        Description = "Conserved graffiti project by 118 artists covering part of the Berlin Wall & celebrating its demise.",
        Search = "East Side Gallery Mühlenstraße, Berlin, Germany"
    };
    
    public static Place Markveien53Street = new()
    {
        Name = "Markveien 53",
        Search = "Markveien53 Oslo, Norway",
        Description = "Address, Markveien 53, 0554 Oslo, Norway",
        Address = "Markveien 53, 0554 Oslo, Norway"
    };
}

public struct Place
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Search { get; set; }
    public string Address { get; set; }
}