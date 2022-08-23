using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersAPI.Data.Requests;

namespace UsersAPI.Services
{
    public class LoginService
    {
        private SignInManager<IdentityUser<int>> _signInManager;

        public LoginService(SignInManager<IdentityUser<int>> signInManager)
        {
            _signInManager = signInManager;
        }

        public Result LogaUsuario(LoginRequest request)
        {
            var resultadoIdentity = _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);
            if (resultadoIdentity.Result.Succeeded) return Result.Ok();
            return Result.Fail("Não foi possivel logar o usuario");
        }
    }
}
