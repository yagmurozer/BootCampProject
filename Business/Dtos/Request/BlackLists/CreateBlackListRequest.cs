
namespace Business.Dtos.Request.BlackLists;

public class CreateBlackListRequest
{
    public Guid ApplicantId { get; set; }
    public string Reason { get; set; }
}
