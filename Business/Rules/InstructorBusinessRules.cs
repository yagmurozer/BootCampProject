

using Core.Rules;
using Repositories.Abstract;

namespace Business.Rules;

public class InstructorBusinessRules : BaseBusinessRules
{

    private readonly IInstructorRepository _instructorRepository;

    public InstructorBusinessRules(IInstructorRepository instructorRepository)
    {
        _instructorRepository = instructorRepository;
    }


}
