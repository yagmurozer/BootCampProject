using Business.Abstracts;
using Business.Dtos.Request.Applications;
using Business.Dtos.Response.Applications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpPost]
    public ActionResult<CreatedApplicationResponse> Add([FromBody] CreateApplicationRequest request)
    {
        return Created("", _applicationService.Add(request));
    }

    [HttpGet]
    public ActionResult<List<GetListApplicationResponse>> GetList()
    {
        return Ok(_applicationService.GetList());
    }

    [HttpGet("{id}")]
    public ActionResult<GetApplicationByIdResponse> GetById(Guid id)
    {
        var request = new GetApplicationByIdRequest { Id = id };
        return Ok(_applicationService.GetById(request));
    }

    [HttpPut]
    public ActionResult<UpdatedApplicationResponse> Update([FromBody] UpdateApplicationRequest request)
    {
        return Ok(_applicationService.Update(request));
    }

    [HttpDelete("{id}")]
    public ActionResult<DeletedApplicationResponse> Delete(Guid id)
    {
        var request = new DeleteApplicationRequest { Id = id };
        return Ok(_applicationService.Delete(request));
    }
}
