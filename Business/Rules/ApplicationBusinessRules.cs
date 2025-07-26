

using Core.Exceptions.Types;
using Core.Rules;
using Entities.Enum;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;

namespace Business.Rules;

public class ApplicationBusinessRules: BaseBusinessRules
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IBlackListRepository _blackListRepository;

    public ApplicationBusinessRules(
        IApplicationRepository applicationRepository,
        IBootcampRepository bootcampRepository,
        IBlackListRepository blackListRepository)
    {
        _applicationRepository = applicationRepository;
        _bootcampRepository = bootcampRepository;
        _blackListRepository = blackListRepository;
    }

    public void CheckIfAlreadyApplied(Guid applicantId, Guid bootcampId)
    {
        var exists = _applicationRepository.Get(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
        if (exists != null)
            throw new Exception("Aynı kişi aynı bootcamp’e birden fazla başvuru yapamaz.");
    }

    public void CheckIfBootcampIsActive(Guid bootcampId)
    {
        var bootcamp = _bootcampRepository.Get(b => b.Id == bootcampId);
        if (bootcamp == null ||
           (bootcamp.BootcampState != BootcampState.OPEN_FOR_APPLICATION &&
            bootcamp.BootcampState != BootcampState.IN_PROGRESS))
        {
            throw new Exception("Başvuru yapılan bootcamp aktif değil.");
        }
    }

    public void CheckIfApplicantBlacklisted(Guid applicantId)
    {
        var blacklisted = _blackListRepository.Get(b => b.ApplicantId == applicantId);
        if (blacklisted != null)
            throw new Exception("Kara listeye alınmış bir aday başvuru yapamaz.");
    }

    public void CheckStatusTransition(ApplicationState currentStatus, ApplicationState newStatus)
    {
        var allowed = new Dictionary<ApplicationState, List<ApplicationState>>
    {
        { ApplicationState.PENDING, new List<ApplicationState> { ApplicationState.APPROVED, ApplicationState.CANCELLED } },
        { ApplicationState.APPROVED, new List<ApplicationState> { ApplicationState.COMPLETED } }  // Varsa tamamlanma durumu
    };

        if (!allowed.ContainsKey(currentStatus) || !allowed[currentStatus].Contains(newStatus))
        {
            throw new Exception($"Geçersiz başvuru durumu geçişi: {currentStatus} → {newStatus}");
        }
    }
}

