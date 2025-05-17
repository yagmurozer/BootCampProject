

using Core.Exceptions.Types;
using Core.Rules;
using Repositories.Abstract;
using Entities.Enum;


namespace Business.Rules;

public class BootcampBusinessRules : BaseBusinessRules
{
    private readonly IBootcampRepository _bootcampRepository;
    private readonly IInstructorRepository _instructorRepository;

    public BootcampBusinessRules(IBootcampRepository bootcampRepository, IInstructorRepository instructorRepository)
    {
        _bootcampRepository = bootcampRepository;
        _instructorRepository = instructorRepository;
    }

    public void CheckIfStartDateIsBeforeEndDate(DateTime startDate, DateTime endDate)
    {
        if (startDate >= endDate)
            throw new BusinessException("Bootcamp start date must be before end date.");
    }

    public async Task CheckIfBootcampNameAlreadyExists(string name)
    {
        var exists = await _bootcampRepository.AnyAsync(b => b.Name == name);
        if (exists)
            throw new BusinessException("A bootcamp with the same name already exists.");
    }

    public async Task CheckIfInstructorExists(Guid instructorId)
    {
        var instructor = await _instructorRepository.GetByIdAsync(instructorId);
        if (instructor == null)
            throw new BusinessException("Instructor does not exist.");
    }

    public async Task CheckIfBootcampIsOpenForApplication(Guid bootcampId)
    {
        var bootcamp = await _bootcampRepository.GetByIdAsync(bootcampId);
        if (bootcamp == null || bootcamp.BootcampState == BootcampState.CANCELLED)
            throw new BusinessException("Bootcamp is not accepting applications.");
    }

}
