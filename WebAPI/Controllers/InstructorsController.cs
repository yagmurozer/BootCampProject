using Business.Abstracts;
using Business.Dtos.Request.Instructors;
using Business.Dtos.Response.Instructors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IInstructorService _instructorService;

        public InstructorsController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpPost]
        public ActionResult<CreatedInstructorResponse> Add([FromBody] CreateInstructorRequest request)
        {
            return Created("", _instructorService.Add(request));
        }

        [HttpGet]
        public ActionResult<List<GetListInstructorResponse>> GetList()
        {
            return Ok(_instructorService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<GetInstructorByIdResponse> GetById(Guid id)
        {
            var request = new GetInstructorByIdRequest { Id = id };
            return Ok(_instructorService.GetById(request));
        }

        [HttpPut]
        public ActionResult<UpdatedInstructorResponse> Update([FromBody] UpdateInstructorRequest request)
        {
            return Ok(_instructorService.Update(request));
        }

        [HttpDelete("{id}")]
        public ActionResult<DeletedInstructorResponse> Delete(Guid id)
        {
            var request = new DeleteInstructorRequest { Id = id };
            return Ok(_instructorService.Delete(request));
        }
    }
}
