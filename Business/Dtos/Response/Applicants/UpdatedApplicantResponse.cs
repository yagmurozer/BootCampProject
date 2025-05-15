namespace Business.Dtos.Response.Applicants;

public class UpdatedApplicantResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }

    //public string Password { get; set; }
    public string NationalIdentity { get; set; }
    public DateTime UpdatedDate { get; set; }
}
