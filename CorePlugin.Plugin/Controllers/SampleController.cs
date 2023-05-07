using CorePlugin.Plugin.Dtos;
using CorePlugin.Plugin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorePlugin.Plugin.Controllers;

#warning This is just a sample. Replace it with your own.
[ApiController]
[Route("[controller]/[action]")]
public class SampleController : ControllerBase
{
    private readonly SampleDbService _sampleDbService;

    public SampleController(SampleDbService sampleDbService) => _sampleDbService = sampleDbService;

    [HttpGet]
    public ActionResult<SampleDto> Test() => Ok(new SampleDto { Description = "Hello World!" });

    [HttpGet]
    [Authorize]
    public ActionResult<SampleDto> AuthorizeTest() => Ok(new SampleDto { Description = "Hello World!" });

    [HttpGet]
    [Authorize]
    public ActionResult<SampleDto> SampleDbRequest() => Ok(new SampleDto { Description = _sampleDbService.GetSampleDbItem() });
}
