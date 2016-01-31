using System.Web.Mvc;
using BTE.Core;
using BTE.Presentation.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;


public class InterfaceInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Classes.FromAssemblyNamed("BTE.RMS.Interface")
            .BasedOn<IFacadeService>().WithService.FromInterface().LifestyleBoundTo<IController>());
        
    }
}
