
using Core.Entities;
using Entities.Enum;

namespace Entities;

public class Bootcamp : BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public BootcampState BootcampState { get; set; }

    // Navigation properties
    public virtual Instructor Instructor { get; set; }
    public virtual ICollection<Application> Applications { get; set; }


    public Bootcamp()
    {
        Applications = new HashSet<Application>();
    }

    public Bootcamp(Guid ıd, string name, Guid instructorId, DateTime startDate, DateTime endDate, BootcampState bootcampState)
    {
        Id = ıd;
        Name = name;
        InstructorId = instructorId;
        StartDate = startDate;
        EndDate = endDate;
        BootcampState = bootcampState;
    }
}
