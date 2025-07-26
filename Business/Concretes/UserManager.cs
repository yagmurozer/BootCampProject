using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Request.User;
using Business.Dtos.Response.User;
using Business.Rules;
using Core.Security.Entites;
using Repositories.Abstract;


namespace Business.Concretes;

public class UserManager : IUserService
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserBusinessRules _businessRules;

    public UserManager(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _businessRules = businessRules;
    }

    public CreatedUserResponse Add(CreateUserRequest request)
    {
        User user = _mapper.Map<User>(request);
        User createdUser = _userRepository.Add(user);
        CreatedUserResponse response = _mapper.Map<CreatedUserResponse>(createdUser);
        return response;
    }

    public DeletedUserResponse Delete(DeleteUserRequest request)
    {
        User user = _userRepository.Get(u => u.Id == request.Id);
        if (user == null)
            throw new Exception("User not found");

        _userRepository.Delete(user);
        DeletedUserResponse response = _mapper.Map<DeletedUserResponse>(user);
        return response;
    }

    public GetUserByIdResponse GetById(GetUserByIdRequest request)
    {
        User user = _userRepository.Get(u => u.Id == request.Id);
        if (user == null)
            throw new Exception("user not found");
        GetUserByIdResponse response = _mapper.Map<GetUserByIdResponse>(user);
        return response;
    }

    public List<GetListUserResponse> GetList()
    {
        List<User> users = _userRepository.GetAll();
        List<GetListUserResponse> responses = _mapper.Map<List<GetListUserResponse>>(users);
        return responses;
    }

    public UpdatedUserResponse Update(UpdateUserRequest request)
    {
        User existingUser = _userRepository.Get(u => u.Id == request.Id);
        if (existingUser == null)
            throw new Exception("User not found");

        _mapper.Map(request, existingUser);
        User updatedUser = _userRepository.Update(existingUser);
        UpdatedUserResponse response = _mapper.Map<UpdatedUserResponse>(updatedUser);
        //Bu UpdateUserRequest sınıfındaki verileri alır, User nesnesine dönüştürür.
        return response;
    }
    public User GetByMail(string email)
    {
        return _userRepository.Get(x => x.Email == email);
    }

    public User AddEntity(User user)
    {
        return _userRepository.Add(user);
    }
}
