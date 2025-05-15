using Business.Abstracts;
using Business.Dtos.Request.Employees;
using Business.Dtos.Response.Employees;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public ActionResult<CreatedEmployeeResponse> Add([FromBody] CreateEmployeeRequest request)
        {
            return Created("", _employeeService.Add(request));
        }

        [HttpGet]
        public ActionResult<List<GetListEmployeeResponse>> GetList()
        {
            return Ok(_employeeService.GetList());
        }

        [HttpGet("{id}")]
        public ActionResult<GetEmployeeByIdResponse> GetById(Guid id)
        {
            var request = new GetEmployeeByIdRequest { Id = id };
            return Ok(_employeeService.GetById(request));
        }

        [HttpPut]
        public ActionResult<UpdatedEmployeeResponse> Update([FromBody] UpdateEmployeeRequest request)
        {
            return Ok(_employeeService.Update(request));
        }

        [HttpDelete("{id}")]
        public ActionResult<DeletedEmployeeResponse> Delete(Guid id)
        {
            var request = new DeleteEmployeeRequest { Id = id };
            return Ok(_employeeService.Delete(request));
        }
    }
}
