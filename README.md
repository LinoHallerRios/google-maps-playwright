[![CI](https://github.com/LinoHallerRios/google-maps-playwright/actions/workflows/Playwright.yml/badge.svg?branch=master)](https://github.com/LinoHallerRios/google-maps-playwright/actions/workflows/Playwright.yml)
![Coverage](https://github.com/LinoHallerRios/google-maps-playwright/blob/badges/.badges/master/coverage.svg)

# Google Maps Playwright Tests

This project is as a playground for me to learn how to use **Playwright** with C#. \
I am currently using the **Google Maps** page for this purpose.

## Set Up

### Tools

In order to run the project in your local machine you will need the following:

- [Net 8.0](https://dotnet.microsoft.com/en-us/download)
- [Powershell](https://docs.microsoft.com/powershell/scripting/install/installing-powershell)
- [Visual Studio (Optional)](https://visualstudio.microsoft.com/downloads/)

  
#### Use the following command to install powershell.
#### Windows
```powershell
winget install --id Microsoft.Powershell --source winget
```
#### MacOS
```bash
brew install powershell/tap/powershell
```

### Project

Donwload the project or clone the repository using [Git](https://git-scm.com/downloads).

Once you have the project on your local computer, open a **terminal** in the project **root**:
- Build the project

  ```powershell
  dotnet build
  ```

   _This will generate the a new `bin` folder with the build._

- Install the required browsers

  ```powershell
  pwsh bin/Debug/net8/playwright.ps1 install --with-deps
  ```
Now you are ready to run the tests!

## Usage
 You can run the tests in three different browsers by using the following commads:
```powershell
dotnet test --settings=chromium.runsettings
```
```powershell
dotnet test --settings=firefox.runsettings
```
```powershell
dotnet test --settings=webkit.runsettings
```

If you want to generate a **coverage** report:
```powershell
dotnet test GoogleMapsPlaywright.csproj /p:CollectCoverage=true /p:IncludeTestAssembly=true /p:CoverletOutputFormat=cobertura --settings=chromium.runsettings
```

You will find a `coverage.cobertura.xml` file with the generated report.

## Configuration

The tests are running in Headful mode, this means that browsers will open when you run the tests.

If you want to run them in headless mode you can edit the `.runsettings` file for each browser.
```xml
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
    <Playwright>
        <BrowserName>chromium</BrowserName>
        <ExpectTimeout>30000</ExpectTimeout>
        <LaunchOptions>
            // Change this to True or False
            <Headless>true</Headless>
        </LaunchOptions>
    </Playwright>
</RunSettings>
```

The tests will now run in the background.

