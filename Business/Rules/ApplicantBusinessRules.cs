

using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;

namespace Business.Rules;

public class ApplicantBusinessRules : BaseBusinessRules
{
    private readonly IApplicantRepository _applicantRepository;
    private readonly IBlackListRepository _blackListRepository;


    public ApplicantBusinessRules(IApplicantRepository applicantRepository, IBlackListRepository blackListRepository)
    {
        _applicantRepository = applicantRepository;
        _blackListRepository = blackListRepository;

    }

    // metotlar bu kısma yazılır
    public async Task CheckIfApplicantWithSameIdentityNumberExists(string identityNumber)
    {
        var exists = await _applicantRepository.AnyAsync(a => a.IdentityNumber == identityNumber);
        if (exists)
            throw new BusinessException("An applicant with the same identity number already exists.");
    }

    public async Task CheckIfApplicantIsBlacklisted(Guid applicantId)
    {
        var isBlacklisted = await _blackListRepository.IsActiveBlackListEntryExists(applicantId);
        if (isBlacklisted)
            throw new BusinessException("Applicant is blacklisted and cannot apply again.");
    }

    public async Task CheckIfApplicantExists(Guid applicantId)
    {
        var applicant = await _applicantRepository.GetByIdAsync(applicantId);
        if (applicant == null)
            throw new BusinessException("Applicant does not exist.");
    }
}
