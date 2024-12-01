using Autofac;
using Carglass.TechnicalAssessment.Backend.Models.Dto;
using Carglass.TechnicalAssessment.Backend.Models.Validator;
using FluentValidation;

namespace Carglass.TechnicalAssessment.Backend.Models;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterValidators(builder);
    }

    private static void RegisterValidators(ContainerBuilder builder)
    {
        builder.RegisterType<ClientDtoValidator>().As<IValidator<ClientDto>>();
    }
}