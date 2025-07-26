using Core.Security.Entites;

namespace Entities;

public class Instructor : User
{
    public string CompanyName { get; set; }
    
    // Navigation properties
    public virtual ICollection<Bootcamp> Bootcamps { get; set; }

    public Instructor(string companyName)
    {
        CompanyName = companyName;
    }

    public Instructor()
    {
        Bootcamps = new HashSet<Bootcamp>();
    }
}
