using eCommerce.Communication.Request;
using eCommerce.Communication.Response;

namespace eCommerce.Application.UseCases.User.Register;

public interface IUserRegisterUseCase
{
    Task<UserRegisterResponse> Executar(UserRegisterRequest request);
}