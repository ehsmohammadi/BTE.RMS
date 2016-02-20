using BTE.Core;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

public class ApplicationServiceInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Classes.FromAssemblyNamed("BTE.RMS.Services")
        .BasedOn<IService>().WithService.FromInterface().LifestyleBoundTo<IFacadeService>());

    }

}