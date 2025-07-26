using Business.Dtos.Request.User;
using Business.Dtos.Response.User;
using Core.Security.Entites;


namespace Business.Abstracts
{
    public interface IUserService
    {
        CreatedUserResponse Add(CreateUserRequest request);
        User AddEntity(User user); // 🔧 Bu satır eklendi
        List<GetListUserResponse> GetList();
        GetUserByIdResponse GetById(GetUserByIdRequest request);
        UpdatedUserResponse Update(UpdateUserRequest request);
        DeletedUserResponse Delete(DeleteUserRequest request);
        User GetByMail(string email);
    }
}
