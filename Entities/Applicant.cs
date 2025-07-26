using Core.Security.Entites;

namespace Entities;

public class Applicant : User
{
    public string About { get; set; }

    // Navigation properties
    public virtual ICollection<Application> Applications { get; set; }
    public virtual BlackList Blacklist { get; set; }

    public Applicant()
    {
        Applications = new HashSet<Application>();
    }
    public Applicant(string about)
    {
        About = about;
    }
}
