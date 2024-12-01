using Carglass.TechnicalAssessment.Backend.Dtos.Clients;
using FluentValidation;

namespace Carglass.TechnicalAssessment.Backend.Dtos.Validator;

public class ClientDtoValidator : AbstractValidator<ClientDto>
{
    public ClientDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEqual(default(int))
            .WithMessage("El Id del producto es necesario.");

        RuleFor(x => x.DocType)
            .NotEmpty()
            .WithMessage("El tipo de documento es necesario.")
            .MaximumLength(25)
            .WithMessage("El tipo de documento tiene una longitud máxima de 25 caracteres.");

        RuleFor(x => x.DocNum)
            .NotEmpty()
            .WithMessage("El número de documento es necesario.")
            .MaximumLength(12)
            .WithMessage("El número de documento tiene una longitud máxima de 12 caracteres.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("El email es necesario.")
            .EmailAddress()
            .WithMessage("El email no cumple el formato adecuado.");

        RuleFor(x => x.GivenName)
            .NotEmpty()
            .WithMessage("El nombre es necesario.")
            .MaximumLength(50)
            .WithMessage("El nombre tiene una longitud máxima de 50 caracteres.");

        RuleFor(x => x.FamilyName1)
            .NotEmpty()
            .WithMessage("El primer apellido es necesario.")
            .MaximumLength(50)
            .WithMessage("El primer apellido tiene una longitud máxima de 50 caracteres.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("El teléfono es necesario.")
            .Matches(@"^\+?\d{10,15}$")
            .WithMessage("El teléfono no cumple el formato adecuado.");
    }
}
