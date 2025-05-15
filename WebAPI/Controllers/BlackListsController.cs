using Business.Abstracts;
using Business.Dtos.Request.BlackLists;
using Business.Dtos.Response.BlackLists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackListsController : ControllerBase
    {
        private readonly IBlackListService _blackListService;

        public BlackListsController(IBlackListService blackListService)
        {
            _blackListService = blackListService;
        }

        [HttpPost]
        public ActionResult<CreatedBlackListResponse> Add([FromBody] CreateBlackListRequest request)
        {
            var result = _blackListService.Add(request);
            return Created("", result);
        }

        [HttpGet]
        public ActionResult<List<GetListBlackListResponse>> GetList()
        {
            return Ok(_blackListService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<GetBlackListByIdResponse> GetById(Guid id)
        {
            var request = new GetBlackListByIdRequest { Id = id };
            return Ok(_blackListService.GetById(request));
        }

        [HttpPut]
        public ActionResult<UpdatedBlackListResponse> Update([FromBody] UpdateBlackListRequest request)
        {
            return Ok(_blackListService.Update(request));
        }

        [HttpDelete("{id}")]
        public ActionResult<DeletedBlackListResponse> Delete(Guid id)
        {
            var request = new DeleteBlackListRequest { Id = id };
            return Ok(_blackListService.Delete(request));
        }
    }
}
