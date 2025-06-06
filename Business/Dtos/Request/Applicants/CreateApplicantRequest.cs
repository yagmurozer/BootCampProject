﻿
namespace Business.Dtos.Request.Applicants;

public class CreateApplicantRequest
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string NationalIdentity { get; set; }
}
