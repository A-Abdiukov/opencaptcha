namespace Captcha.Core.Services;
using System.Drawing.Imaging;
using Microsoft.AspNetCore.Mvc;
using Models;

public class CaptchaService : ICaptchaService
{
    public async Task<FileContentResult> CreateCaptchaImageAsync(CaptchaConfigurationData config)
    {
        var image = new CaptchaImage(config);

        // Save the image to a memory stream so we can return it as a file
        await using var ms = new MemoryStream();
        image.Value.Save(ms, ImageFormat.Jpeg);
        var imageBytes = ms.ToArray();

        // Return the image as a jpeg file
        return new FileContentResult(imageBytes, "image/jpeg");
    }
}
