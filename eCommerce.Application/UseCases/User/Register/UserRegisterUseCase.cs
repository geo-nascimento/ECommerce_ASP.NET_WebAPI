using AutoMapper;
using eCommerce.Application.Services.Encrypt;
using eCommerce.Application.Services.Token;
using eCommerce.Application.Services.Validator;
using eCommerce.Communication.Request;
using eCommerce.Communication.Response;
using eCommerce.Domain.Interfaces.User;
using eCommerce.Exceptions;
using eCommerce.Exceptions.BabeExceptions;
using eCommerce.Infrastructure.Repositories;
using FluentValidation.Results;

namespace eCommerce.Application.UseCases.User.Register;

public class UserRegisterUseCase : IUserRegisterUseCase
{
    private readonly IUserWriteOnlyRepository _repoWrite;
    private readonly IUsuarioReadOnlyRepository _repoRead;
    private readonly IUnitOfWork _uof;
    private readonly PasswordEncryptor _encrypt;
    private readonly IMapper _map;
    private readonly TokenController _token;

    public UserRegisterUseCase(IUserWriteOnlyRepository repoWrite, 
        IUsuarioReadOnlyRepository repoRead,
        IUnitOfWork uof,
        PasswordEncryptor encrypt,
        IMapper map,
        TokenController token)
    {
        _repoWrite = repoWrite;
        _repoRead = repoRead;
        _uof = uof;
        _encrypt = encrypt;
        _map = map;
        _token = token;
    }
    
    //TODO Implementar pós validação
    public async Task<UserRegisterResponse> Executar(UserRegisterRequest request)
    {
        await ToValidate(request);

        var model = _map.Map<Domain.Models.User>(request);
        model.Password = _encrypt.Criptografar(request.Password);
        await _repoWrite.AddUser(model);
        _uof.Commit();
        //Resposta com o token
        var token = _token.CreateToken(model.Email);

        return new UserRegisterResponse() { Token = token };

    }

    private async Task ToValidate(UserRegisterRequest request)
    {
        //Validar request
        var validator = new UserRegisterValidator();
        var result = validator.Validate(request);
        
        //Validar e-mail
        var queryThereIsUserWithEmail = await _repoRead.ExitUserWithEmail(request.Email);

        if (queryThereIsUserWithEmail)
        {
            result.Errors.Add(new ValidationFailure("email", ResourcesErrosMessages.ERRRO_EMAIL_JA_CADASTRADO));
        }

        if (!result.IsValid)
        {
            var errorMsg = result.Errors.Select(c => c.ErrorMessage).ToList();
            throw new UserRegisterValidationError(errorMsg);
        }
        
    }
}