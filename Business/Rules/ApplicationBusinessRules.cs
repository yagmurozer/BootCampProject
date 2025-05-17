

using Core.Exceptions.Types;
using Core.Rules;
using Entities.Enum;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;

namespace Business.Rules;

public class ApplicationBusinessRules : BaseBusinessRules
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IBlackListRepository _blackListRepository;

    public ApplicationBusinessRules(IApplicationRepository applicationRepository, IBootcampRepository bootcampRepository, IBlackListRepository blackListRepository)
    {
        _applicationRepository = applicationRepository;
        _bootcampRepository = bootcampRepository;
        _blackListRepository = blackListRepository;
    }

    public async Task CheckIfAlreadyApplied(Guid applicantId, Guid bootcampId)
    {
        var exists = await _applicationRepository.AnyAsync(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
        if (exists)
            throw new BusinessException("Applicant has already applied to this bootcamp.");
    }

    public async Task CheckIfBootcampIsActive(Guid bootcampId)
    {
        var bootcamp = await _bootcampRepository.GetByIdAsync(bootcampId);

        if (bootcamp == null || bootcamp.BootcampState != BootcampState.OPEN_FOR_APPLICATION)
            throw new BusinessException("The bootcamp applied for must be active.");
    }

    public async Task CheckIfApplicantIsBlacklisted(Guid applicantId)
    {
        var isBlackListed = await _blackListRepository.IsActiveBlackListEntryExists(applicantId);
        if (isBlackListed)
            throw new BusinessException("Blacklisted applicants cannot submit applications.");
    }

    public void CheckIfApplicationStateTransitionIsValid(ApplicationState currentState, ApplicationState newState)
    {
        var allowedTransitions = new Dictionary<ApplicationState, List<ApplicationState>>
    {
        { ApplicationState.PENDING, new List<ApplicationState> { ApplicationState.APPROVED, ApplicationState.REJECTED } },
        { ApplicationState.APPROVED, new List<ApplicationState>() },
        { ApplicationState.REJECTED, new List<ApplicationState>() },
        { ApplicationState.CLOSED, new List<ApplicationState>() }
    };

        if (!allowedTransitions.ContainsKey(currentState) || !allowedTransitions[currentState].Contains(newState))
            throw new BusinessException($"Invalid status transition from {currentState} to {newState}.");
    }



}
