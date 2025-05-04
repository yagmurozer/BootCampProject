using Business.Abstracts;
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
    public void Add([FromBody] Applicant applicant)
    {
        _applicantService.Add(applicant);
    }

    [HttpGet]
    public List<Applicant> GetAll()

    {
        return _applicantService.GetAll();
    }

}
