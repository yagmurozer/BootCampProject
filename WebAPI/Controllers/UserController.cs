using Business.Abstracts;
using Business.Dtos.Request.User;
using Business.Dtos.Response.User;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult<CreatedUserResponse> Add([FromBody] CreateUserRequest request)
        {
            var createdUser = _userService.Add(request);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet]
        public ActionResult<List<GetListUserResponse>> GetList()
        {
            var users = _userService.GetList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<GetUserByIdResponse> GetById(Guid id)
        {
            var request = new GetUserByIdRequest { Id = id };
            var user = _userService.GetById(request);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult<UpdatedUserResponse> Update(Guid id, [FromBody] UpdateUserRequest request)
        {
            if (id != request.Id)
                return BadRequest("ID ile request içindeki ID uyuşmuyor.");

            var updatedUser = _userService.Update(request);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public ActionResult<DeletedUserResponse> Delete(Guid id)
        {
            var request = new DeleteUserRequest { Id = id };
            var deletedUser = _userService.Delete(request);
            return Ok(deletedUser);
        }
    }
}
