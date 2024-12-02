using Autofac;
using Carglass.TechnicalAssessment.Models.Dto;
using Carglass.TechnicalAssessment.Models.Validator;
using FluentValidation;

namespace Carglass.TechnicalAssessment.Models;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterValidators(builder);
    }

    private static void RegisterValidators(ContainerBuilder builder)
    {
        builder.RegisterType<ClientDtoValidator>().As<IValidator<ClientDto>>();
        builder.RegisterType<ProductDtoValidator>().As<IValidator<ProductDto>>();
    }
}