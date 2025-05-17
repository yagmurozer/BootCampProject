

using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstract;
using Repositories.Concrete.EntityFramework;

namespace Business.Rules;

public class BlackListBusinessRules : BaseBusinessRules
{
    private readonly IBlackListRepository _blackListRepository;

    public BlackListBusinessRules(IBlackListRepository blackListRepository)
    {
        _blackListRepository = blackListRepository;
    }

    public async Task CheckIfActiveBlacklistExists(Guid applicantId)
    {
        var exists = await _blackListRepository.IsActiveBlackListEntryExists(applicantId); //bu metotları repoda da belirtmeliyiz.
        if (exists)
            throw new BusinessException("Applicant already has an active blacklist entry.");
    }

    public void CheckIfReasonIsProvided(string reason)
    {
        if (string.IsNullOrWhiteSpace(reason))
            throw new BusinessException("Reason for blacklist entry cannot be empty.");
    }

}
