using Rotativaio.AspNetCore;

RotativaIoConfiguration.SetRotativaIoUrl("https://example.rotativa.io");
RotativaIoConfiguration.SetRotativaIoApiKey("dummy-api-key");

var result = new ViewAsPdf
{
    ViewName = "Smoke",
    PageSize = Size.A4,
    PageOrientation = Orientation.Portrait,
};

System.Console.WriteLine($"[.NET Framework 4.7.2] ViewAsPdf constructed OK: PageSize={result.PageSize}");
