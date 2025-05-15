using Business.Abstracts;
using Business.Dtos.Request.Applicants;
using Business.Dtos.Response.Applicants;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicantsController : ControllerBase
{
    private readonly IApplicantService _applicantService;

    public ApplicantsController(IApplicantService applicantService)
    {
        _applicantService = applicantService;
    }


    [HttpPost]
    public ActionResult<CreatedApplicantResponse> Add([FromBody] CreateApplicantRequest request) // hangi hhtp kodunun döndüğünü action resut ile çalışılır
    {
        return Created("", _applicantService.Add(request));
        // created metot u conr-troller baseden gelir
    }
    [HttpGet]
    public ActionResult<List<GetListApplicantResponse>> GetList()
    { 
        return Ok(_applicantService.GetList());
    }

    // GET: api/Applicants/{id}
    [HttpGet("{id}")]
    public ActionResult<GetApplicantByIdResponse> GetById(Guid id)
    {
        var request = new GetApplicantByIdRequest { Id = id };
        var result = _applicantService.GetById(request);
        return Ok(result);
    }

    // PUT: api/Applicants
    [HttpPut]
    public ActionResult<UpdatedApplicantResponse> Update([FromBody] UpdateApplicantRequest request)
    {
        var result = _applicantService.Update(request);
        return Ok(result);
    }

    // DELETE: api/Applicants/{id}
    [HttpDelete("{id}")]
    public ActionResult<DeletedApplicantResponse> Delete(Guid id)
    {
        var request = new DeleteApplicantRequest { Id = id };
        var result = _applicantService.Delete(request);
        return Ok(result);
    }

}
