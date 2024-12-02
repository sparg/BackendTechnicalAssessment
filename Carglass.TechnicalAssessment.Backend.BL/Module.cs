using Autofac;
using Carglass.TechnicalAssessment.Data.IRepositories;
using Carglass.TechnicalAssessment.Data.Repositories;
using System.Reflection;

namespace Carglass.TechnicalAssessment.Services;

public class Module : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        RegisterApplicationServices(builder);
        RegisterRepositories(builder);
    }

    private static void RegisterApplicationServices(ContainerBuilder builder)
    {
        builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            .Where(x => !x.IsAbstract && !x.IsInterface && x.Name.EndsWith("Service"))
            .AsImplementedInterfaces()
            .InstancePerDependency();
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
