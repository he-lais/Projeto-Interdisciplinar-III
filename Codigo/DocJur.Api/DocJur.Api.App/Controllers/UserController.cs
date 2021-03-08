using DocJur.Api.App.Models.Requests.Users;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.Users;
using DocJur.Api.App.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocJur.Api.App.Controllers
{
    /// <summary>
    /// Controller for User related requests.
    /// </summary>
    public class UserController : Controller
    {
        private IUserService UserService { get; }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<UserLoginResponse> Login([FromBody] UserLoginRequest userLoginRequest) => UserService.ProcessLogin(userLoginRequest);

        public ActionResult<UserListResponse> List() => UserService.GetUsersList();

        public ActionResult<UserResponse> Details([FromBody] UserIdRequest userIdRequest) => UserService.GetUser(userIdRequest);

        [HttpPost]
        public ActionResult<UserResponse> Create([FromBody] UserCreateRequest userCreateRequest) => UserService.Create(userCreateRequest);

        [HttpPost]
        public ActionResult<UserResponse> Update([FromBody] UserUpdateRequest userUpdateRequest) => UserService.Update(userUpdateRequest);

        [HttpPost]
        public ActionResult<BasicResponse> Delete([FromBody] UserIdRequest userIdRequest) => UserService.Delete(userIdRequest);

        public UserController(IUserService userService) => UserService = userService;


    }
}