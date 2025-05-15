using Business.Abstracts;
using Business.Dtos.Request.Bootcamps;
using Business.Dtos.Response.Bootcamps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BootcampsController : ControllerBase
    {
        private readonly IBootcampService _bootcampService;

        public BootcampsController(IBootcampService bootcampService)
        {
            _bootcampService = bootcampService;
        }

        [HttpPost]
        public ActionResult<CreatedBootcampResponse> Add([FromBody] CreateBootcampRequest request)
        {
            return Created("", _bootcampService.Add(request));
        }

        [HttpGet]
        public ActionResult<List<GetListBootcampResponse>> GetList()
        {
            return Ok(_bootcampService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<GetBootcampByIdResponse> GetById(Guid id)
        {
            var request = new GetBootcampByIdRequest { Id = id };
            return Ok(_bootcampService.GetById(request));
        }

        [HttpPut]
        public ActionResult<UpdatedBootcampResponse> Update([FromBody] UpdateBootcampRequest request)
        {
            return Ok(_bootcampService.Update(request));
        }

        [HttpDelete("{id}")]
        public ActionResult<DeletedBootcampResponse> Delete(Guid id)
        {
            var request = new DeleteBootcampRequest { Id = id };
            return Ok(_bootcampService.Delete(request));
        }
    }
}
