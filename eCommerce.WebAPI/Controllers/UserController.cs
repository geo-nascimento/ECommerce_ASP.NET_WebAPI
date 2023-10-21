using eCommerce.Application.UseCases.User.Register;
using eCommerce.Communication.Request;
using eCommerce.Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.WebAPI.Controllers;

public class UserController : eCommerceControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(UserRegisterResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser(
        [FromServices] IUserRegisterUseCase useCase, 
        UserRegisterRequest request)
    {
        var result = await useCase.Executar(request);

        return Created(string.Empty, result);
    }
}