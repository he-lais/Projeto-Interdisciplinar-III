using DocJur.Api.App.Models.Requests.Users;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.Users;

namespace DocJur.Api.App.Services
{
    /// <summary>
    /// Service that process authentication.
    /// </summary>
    public interface IUserService
    {
        UserLoginResponse ProcessLogin(UserLoginRequest userLoginRequest);
        UserListResponse GetUsersList();
        UserResponse GetUser(UserIdRequest userIdRequest);
        UserResponse Create(UserCreateRequest userCreateRequest);
        UserResponse Update(UserUpdateRequest userUpdateRequest);
        BasicResponse Delete(UserIdRequest userIdRequest);
    }
}
