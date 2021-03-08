using DocJur.Api.App.Models;
using DocJur.Api.App.Models.Requests.Users;
using DocJur.Api.App.Models.Responses;
using DocJur.Api.App.Models.Responses.Users;
using DocJur.Api.App.Repository;
using DocJur.Api.App.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DocJur.Api.App.Services.Impl
{
    /// <summary>
    /// Service that process authentication.
    /// </summary>
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; set; }

        private const string ERROR_USER_NOT_FOUND = "Usuário não encontrado. Cheque as informações enviadas e tente novamente.";
        private const string SUCCESS_AUTHENTICATION = "Usuário autenticado com sucesso.";

        public UserLoginResponse ProcessLogin(UserLoginRequest userLoginRequest)
        {
            try
            {
                User user = UserRepository.FindByUsernameAndPassword(userLoginRequest.Username, userLoginRequest.Password);

                if (user == null)
                {
                    throw new DocJurException(ERROR_USER_NOT_FOUND);
                }

                // TODO: generate token

                return new UserLoginResponse()
                {
                    Success = true,
                    Message = SUCCESS_AUTHENTICATION,
                    Token = "not implemented",
                    Name = user.Username,
                    Id = user.Id
                };
            }
            catch (Exception ex)
            {
                return new UserLoginResponse { Success = false, Message = ex.Message };
            }
        }

        public UserListResponse GetUsersList()
        {
            try
            {
                IList<User> users = UserRepository.FindAll();
                users?.ForEach(user => user.ClearPassword());

                UserListResponse userIndexResponse = new UserListResponse { Success = true };
                userIndexResponse.Users = users;

                return userIndexResponse;
            }
            catch (Exception e)
            {
                return new UserListResponse { Success = false, Message = e.Message };
            }
        }

        public UserResponse GetUser(UserIdRequest userIdRequest)
        {
            try
            {
                User user = UserRepository.Find(userIdRequest.UserId);

                if (user == null)
                {
                    return new UserResponse { Success = false, Message = ERROR_USER_NOT_FOUND };
                }

                user.ClearPassword();

                return new UserResponse { Success = true, User = user };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, Message = e.Message };
            }
        }

        public UserResponse Create(UserCreateRequest userCreateRequest)
        {
            try
            {
                ValidateUserData(userCreateRequest);

                if (UserRepository.FindByUsername(userCreateRequest.Username) != null)
                {
                    throw new DocJurException($"Já existe um usuário com o nome de usuário {userCreateRequest.Username}.");
                }

                User user = new User
                {
                    Email = userCreateRequest.Email,
                    Password = userCreateRequest.Password,
                    Username = userCreateRequest.Username
                };

                UserRepository.Add(user);
                user.ClearPassword();

                return new UserResponse { Success = true, User = user, Message = $"Usuário {user.Username} criado com sucesso." };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, Message = e.Message };
            }
        }

        public UserResponse Update(UserUpdateRequest userUpdateRequest)
        {
            try
            {
                ValidateUserData(userUpdateRequest);
                User user = UserRepository.Find(userUpdateRequest.Id);

                if (user == null)
                {
                    return new UserResponse { Success = false, Message = ERROR_USER_NOT_FOUND };
                }

                user.Email = userUpdateRequest.Email;
                user.Password = userUpdateRequest.Password;
                user.Username = userUpdateRequest.Username;
                UserRepository.Update(user);
                user.ClearPassword();

                return new UserResponse { Success = true, User = user, Message = $"Usuário {user.Username} editado com sucesso." };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, Message = e.Message };
            }
        }

        private void ValidateUserData(UserCreateRequest userCreateRequest)
        {
            if (userCreateRequest.Email.IsEmpty())
            {
                throw new DocJurException("Usuário deve ter um e-mail.");
            }

            if (!new EmailAddressAttribute().IsValid(userCreateRequest.Email))
            {
                throw new DocJurException("O e-mail enviado é inválido.");
            }

            if (userCreateRequest.Password.IsEmpty())
            {
                throw new DocJurException("Usuário deve ter uma senha.");
            }

            if (userCreateRequest.Username.IsEmpty())
            {
                throw new DocJurException("Usuário deve ter nome de usuário.");
            }
        }

        public BasicResponse Delete(UserIdRequest userIdRequest)
        {
            try
            {
                User user = UserRepository.Find(userIdRequest.UserId);

                if (user == null)
                {
                    return new UserResponse { Success = false, Message = ERROR_USER_NOT_FOUND };
                }

                UserRepository.Delete(user);

                return new UserResponse { Success = true, Message = $"Usuário excluído com sucesso." };
            }
            catch (Exception e)
            {
                return new UserResponse { Success = false, Message = e.Message };
            }
        }

        public UserService(IUserRepository userRepository) => UserRepository = userRepository;
    }
}