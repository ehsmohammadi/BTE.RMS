using BTE.Core;
using BTE.RMS.Model.Meetings;
using BTE.RMS.Persistence;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

public class RepositoryInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(Classes.FromAssemblyNamed("BTE.RMS.Persistence")
        .BasedOn<IRepository>().WithService.FromInterface().LifestyleBoundToNearest<IFacadeService>());
        container.Register(Component.For<RMSContext>().LifestyleBoundTo<IFacadeService>());

        container.Register(Component.For<IMeetingRepository>().ImplementedBy<MeetingRepository>().Named("TransientRepository").LifestyleTransient().DependsOn(new { rmsContext =new RMSContext()}));
        //container.Register(Component.For<RMSContext>().NamedAutomatically("TransientContext").LifestyleTransient());
    }

}