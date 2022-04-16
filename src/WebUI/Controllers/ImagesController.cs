using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Images.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace CleanArchitecture.WebUI.Controllers;

public class ImagesController : ApiControllerBase
{
    private readonly IIMageService _mageService;

    public ImagesController(IIMageService mageService)
    {
        _mageService = mageService;
    }

    private IActionResult ReturnImage(byte[]? image)
    {
        var headers = this.Response.GetTypedHeaders();
        headers.CacheControl = new CacheControlHeaderValue
        {
            Public = true,
            MaxAge = TimeSpan.FromDays(2)
        };
        headers.Expires = new DateTimeOffset(DateTime.UtcNow.AddDays(2));

#pragma warning disable CS8604 // Possible null reference argument.
        return File(image, "image/jpeg");
#pragma warning restore CS8604 // Possible null reference argument.
    }

    [HttpPost]
    [RequestSizeLimit(100 * 1024 * 1024)]
    public async Task<IActionResult> Upload(CancellationToken cancellationToken)
    {
        try
        {
            var images = Request.Form.Files;
            int idPropriete = Convert.ToInt32(Request.Form["idPropriete"]);
            if (images.Count() > 10)
            {
                this.ModelState.AddModelError("Images", "You Cannot upload more than 10 photos");
            }

            if (images.Any(i => i.Length > 10 * 1024 * 1024))
            {
                this.ModelState.AddModelError("Images", "You Cannot upload image more than 10 Mb");
            }

            long size = images.Sum(f => f.Length);

            await _mageService.ProcessSF(images.Select(i => new ImageInputModel()
            {
                Name = i.FileName,
                Type = i.ContentType,
                Content = i.OpenReadStream()
            }), idPropriete, cancellationToken);

            return Ok(new { count = images.Count(), size });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex}");
        }
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetAll(int id)
    {
        return await Mediator.Send(new GetAllImagesQuery { ProprieteId = id });
    }

    [HttpGet("Thumbnail")]
    public async Task<IActionResult> Thumbnail([FromQuery] Guid guid)
    {
        var res = await Mediator.Send(new GetImageQuery { PhotoId = guid, Size = "thumbnail" });
        return ReturnImage(res);
    }

    [HttpGet("SizeList")]
    public async Task<IActionResult> ListSize(Guid guid)
    {
        var res = await Mediator.Send(new GetImageQuery { PhotoId = guid, Size = "list" });
        return ReturnImage(res);
    }

    [HttpGet("FullSize")]
    public async Task<IActionResult> FullSize(Guid guid)
    {
        var res = await Mediator.Send(new GetImageQuery { PhotoId = guid, Size = "full" });
        return ReturnImage(res);
    }
}