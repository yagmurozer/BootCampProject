

using Core.Entities;
using Entities.Enum;

namespace Entities
{
    public class Application : BaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid ApplicantId { get; set; }
        public Guid BootcampId { get; set; }
        public ApplicationState ApplicationState { get; set; }
        
        
        // Navigation properties
        public virtual Applicant Applicant { get; set; }
        public virtual Bootcamp Bootcamp { get; set; }

        public Application() { }

        public Application(Guid ıd, Guid applicantId, Guid bootcampId, ApplicationState applicationState)
        {
            Id = ıd;
            ApplicantId = applicantId;
            BootcampId = bootcampId;
            ApplicationState = applicationState;
        }


    }
}
