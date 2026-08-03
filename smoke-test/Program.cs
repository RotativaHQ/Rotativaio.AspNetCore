using System;
using Rotativaio.AspNetCore;

RotativaIoConfiguration.SetRotativaIoUrl("https://example.rotativa.io");
RotativaIoConfiguration.SetRotativaIoApiKey("dummy-api-key");

var result = new ViewAsPdf
{
    ViewName = "Smoke",
    PageSize = Size.A4,
    PageOrientation = Orientation.Portrait,
};

Console.WriteLine($"[{System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription}] " +
                   $"ViewAsPdf constructed OK: PageSize={result.PageSize}");
