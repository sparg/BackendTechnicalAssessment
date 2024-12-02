using Autofac;
using Carglass.TechnicalAssessment.Data.IRepositories;
using Carglass.TechnicalAssessment.Data.Repositories;

namespace Carglass.TechnicalAssessment.Data;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterRepositories(builder);
    }

    private static void RegisterRepositories(ContainerBuilder builder)
    {
        builder.RegisterType<ClientRepository>()
            .As<IClientRepository>()
            .InstancePerDependency();

        builder.RegisterType<ProductRepository>()
            .As<IProductRepository>()
            .InstancePerDependency();
    }
}