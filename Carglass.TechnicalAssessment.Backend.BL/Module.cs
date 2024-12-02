using Autofac;
using Carglass.TechnicalAssessment.Backend.DL.Repositories;
using System.Reflection;

namespace Carglass.TechnicalAssessment.Backend.BL;

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
