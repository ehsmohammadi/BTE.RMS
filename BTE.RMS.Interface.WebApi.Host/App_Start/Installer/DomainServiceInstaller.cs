using BTE.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

public class DomainServiceInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Classes.FromAssemblyNamed("BTE.RMS.Model")
        .BasedOn<IDomainService>().WithService.FromInterface().LifestyleBoundTo<IService>());

    }

}