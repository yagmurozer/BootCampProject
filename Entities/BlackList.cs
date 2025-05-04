

using Core.Entities;

namespace Entities;

public class BlackList: BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
    public Guid ApplicantId { get; set; }
    
    // Navigation property
    public virtual Applicant Applicant { get; set; }

    public BlackList() { }
    public BlackList(Guid id, string reason, DateTime date, Guid ApplicantId)
    {
        Id = id;
        Reason = reason;
        Date = date;
        ApplicantId = ApplicantId;
    }
}
