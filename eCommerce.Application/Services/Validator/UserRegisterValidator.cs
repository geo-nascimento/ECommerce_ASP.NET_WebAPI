using System.Text.RegularExpressions;
using eCommerce.Communication.Request;
using eCommerce.Exceptions;
using FluentValidation;
using FluentValidation.Results;

namespace eCommerce.Application.Services.Validator;

public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage(ResourcesErrosMessages.ERRO_NOME_VAZIO);
        RuleFor(c => c.Email).NotEmpty().WithMessage(ResourcesErrosMessages.ERRO_EMAIL_VAZIO);
        RuleFor(c => c.Password).NotEmpty().WithMessage(ResourcesErrosMessages.ERRO_SENHA_VAZIA);
        RuleFor(c => c.PhoneNumber).NotEmpty().WithMessage(ResourcesErrosMessages.ERRO_TELEFONE_VAZIO);

        When(c => !string.IsNullOrWhiteSpace(c.Email), () =>
        {
            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage(ResourcesErrosMessages.ERRO_EMAIL_INVALIDO);
        });

        When(c => !string.IsNullOrWhiteSpace(c.Password), () =>
        {
            RuleFor(c => c.Password).Custom((password, context) =>
            {
                string pattern = "^(?=.*[a-zA-Z0-9])(?=.*[^a-zA-Z0-9]).{6,}$";
                var isMatch = Regex.IsMatch(password, pattern);

                if (!isMatch)
                {   
                    context.AddFailure(new ValidationFailure(nameof(password), ResourcesErrosMessages.ERRO_SENHA_INVALIDA));
                }
            });
        });
        
        When(c => !string.IsNullOrWhiteSpace(c.PhoneNumber), () =>
        {
            RuleFor(c => c.PhoneNumber).Custom((phoneNumber, context) =>
            {
                string pattern = "[0-9]{2} [1-9]{1} [0-9]{4}-[0-9]{4}";
                var isMatch = Regex.IsMatch(phoneNumber, pattern);

                if (!isMatch)
                {   
                    context.AddFailure(new ValidationFailure(nameof(phoneNumber), ResourcesErrosMessages.ERRO_TELEFONE_INVALIDO));
                }
            });
        });
    }
}