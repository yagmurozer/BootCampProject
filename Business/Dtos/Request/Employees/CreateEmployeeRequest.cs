﻿
namespace Business.Dtos.Request.Employees;

public class CreateEmployeeRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public string Email { get; set; }

}
