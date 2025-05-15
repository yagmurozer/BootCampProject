namespace Business.Dtos.Response.Applicants;

public class DeletedApplicantResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public DateTime DeletedDate { get; set; } // Eğer `soft delete` varsa, kullanılabilir
}
